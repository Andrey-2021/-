using GameActionsForAll;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ViewInterfaces;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс. View главного окна игры
    /// </summary>
    public  class ViewMain : IViewInterfaceForController
    {
        /// <summary>
        /// Model этого окна
        /// </summary>
        readonly IModelInterfaceForViewer _model;

        /// <summary>
        /// Windows-окно с которым работаем
        /// </summary>
        ViewMainWindow _window;

        public event EventHandler StartingGame;
        public event EventHandler StoppingGame;
        public event EventHandler ClosingGame;
        public event EventHandler<GameActions> KeyPressed;

        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parModel">Модель</param>
        public ViewMain(IModelInterfaceForViewer parModel)
        {

            _window = new ViewMainWindow();
            _window.dataGridViewGameBox.SelectionChanged += dataGridView1_SelectionChanged;
            _window.KeyDown += ViewMainFormKeyDown;
            _window.buttonClose.Click += ButtonCloseClick;
            _window.buttonStart.Click += ButtonStartClick;
            _window.buttonStop.Click += ButtonStopClick;
            _window.FormClosing += ViewMainFormFormClosing;
            _window.HelpToolStripMenuItem.Click += HelpToolStripMenuItemClick;
            _window.RezultsToolStripMenuItem.Click += RezultsToolStripMenuItemClick;
            _window.SettingsToolStripMenuItem.Click += SettingsToolStripMenuItemClick;


            //InitializeComponent();
            this._model = parModel;
            Init();
        }

        /// <summary>
        /// Начать работу с окном
        /// </summary>
        public void Go()
        {
            Application.Run(_window);
        }

        /// <summary>
        /// Начальная настройка
        /// </summary>
        void Init()
        {
            InitModel();
            IntitDataGridBoard();
        }


        /// <summary>
        /// Подписываемся на события модели
        /// </summary>
        void InitModel()
        {
            _model.SyncContext = SynchronizationContext.Current;
            _model.ScoreChanged += RevreshScore;
            _model.BordChanged += RefreshBoard;
            _model.GameEnded += GameOver;
            _model.CanClosingViewer += ClosingForm;
            _model.CreatedNewBord += NewBord;
        }

        /// <summary>
        /// Создать новую доску
        /// </summary>
        void NewBord(Object obj, GameBox parGameBox)
        {
            IntitDataGridBoard();
            RefreshBoard(null, null);
        }


        /// <summary>
        /// Метод события. Используемый для создания события "Начало игры"
        /// </summary>
        void OnStartingGame()
        {
            SetupOnGameStarting();
            StartingGame?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события "Остановка игры"
        /// </summary>
        void OnStoppingGame()
        {
            SetupWhenEndGame();
            StoppingGame?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события "Остановка игры"
        /// </summary>
        void OnClosingGame()
        {
            //SetupWhenEndGame();

            if (ClosingGame != null)
                ClosingGame.Invoke(this, EventArgs.Empty);
            else
                ClosingForm(this, EventArgs.Empty);
        }




        /// <summary>
        /// Метод подписанный на событие окончания игры в Model.
        /// </summary>
        protected void GameOver(object sender, EventArgs eArg)
        {
            SetupWhenEndGame();
            //MessageBox.Show("Конец!");
            KeyPressed?.Invoke(this, GameActions.GameOver);
        }



        /// <summary>
        /// Метод настраивает элементы окна когда игра началась
        /// </summary>
        void SetupOnGameStarting()
        {
            _window.buttonStart.Enabled = false;
            _window.buttonStop.Enabled = true;
        }

        /// <summary>
        /// Метод настраивает элементы окна когда игра закончилась
        /// </summary>
        void SetupWhenEndGame()
        {
            _window.buttonStart.Enabled = true;
            _window.buttonStop.Enabled = false;
        }




        /// <summary>
        /// Настройка DataGrid. Используется для отображения игрового поля.
        /// </summary>
        void IntitDataGridBoard()
        {
            //Ширина ячейки DataGrid
            const int columnWidth = 25;
            //Высота ячейки DataGrid
            const int columnHeight = columnWidth;

            _window.dataGridViewGameBox.RowHeadersVisible = false;
            _window.dataGridViewGameBox.ColumnHeadersVisible = false;
            _window.dataGridViewGameBox.AllowUserToResizeColumns = false;
            _window.dataGridViewGameBox.AllowUserToResizeRows = false;
            _window.dataGridViewGameBox.Enabled = false;
            _window.dataGridViewGameBox.ScrollBars = ScrollBars.None;



            var bord = _model.GetBoard;

            int BordRows = bord.GetLength(0);
            int BordColumns = bord.GetLength(1);

            _window.dataGridViewGameBox.ColumnCount = BordColumns;
            _window.dataGridViewGameBox.RowCount = BordRows;
            _window.dataGridViewGameBox.Height = BordRows * columnWidth;
            _window.dataGridViewGameBox.Width = BordColumns * columnHeight;

            //Отключить выделение ячеек 
            _window.dataGridViewGameBox.DefaultCellStyle.SelectionBackColor = Color.Aqua;//  model.BackgroundBordColor;
            _window.dataGridViewGameBox.DefaultCellStyle.SelectionForeColor = _model.BackgroundBordColor.ConvertToColor();
            _window.dataGridViewGameBox.CurrentCell = null;
            //dataGridView1.SelectedCells[0].Selected = false;
            _window.dataGridViewGameBox.ClearSelection();

            //устанавливаем высоту всех строк в dataGrid
            for (int i = 0; i < BordRows; i++)
                _window.dataGridViewGameBox.Rows[i].Height = columnHeight;

            //устанавливаем ширину всех колонок в dataGrid
            for (int i = 0; i < BordColumns; i++)
                _window.dataGridViewGameBox.Columns[i].Width = columnWidth;
        }


        //Убираем выделенную ячейку, в правом верхнем углу
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //suppresss the SelectionChanged event
            _window.dataGridViewGameBox.SelectionChanged -= dataGridView1_SelectionChanged;

            //grab the selectedIndex, if needed, for use in your custom code
            // do your custom code here

            // finally, clear the selection & resume (reenable) the SelectionChanged event 
            _window.dataGridViewGameBox.ClearSelection();
            _window.dataGridViewGameBox.SelectionChanged += dataGridView1_SelectionChanged;
        }


        /// <summary>
        /// Обновляем изображение игрового поля
        /// </summary>
        void RefreshBoard(object sender, EventArgs ea)
        {
            var colors = _model.GetBoard;

            int BordRows = colors.GetLength(0);
            int BordColumns = colors.GetLength(1);

            for (int i = 0; i < BordRows; i++)
            {
                for (int j = 0; j < BordColumns; j++)
                {
                    _window.dataGridViewGameBox.Rows[i].Cells[j].Style.BackColor = colors[i, j].ConvertToColor();
                }
            }
        }



        /// <summary>
        /// Обновляем счёт
        /// </summary>
        void RevreshScore(object sender, EventArgs ea)
        {
            _window.textBoxScore.Text = _model.Score.ToString();
        }

        /// <summary>
        /// Закрыть программу
        /// </summary>
        void ClosingForm(object sender, EventArgs ea)
        {
            canClose = true;
            Application.Exit();
        }





        /// <summary>
        /// Преобразование нажатой кнопки в команду для Controller
        /// </summary>
        private void ViewMainFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                e.Handled = false;
                KeyPressed?.Invoke(this, GameActions.moveLeft);
            }

            if (e.KeyCode == Keys.Right)
            {
                e.Handled = false;
                KeyPressed?.Invoke(this, GameActions.moveRight);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = false;
                KeyPressed?.Invoke(this, GameActions.moveDown);
            }

            if (e.KeyCode == Keys.Z)
            {
                e.Handled = false;
                KeyPressed?.Invoke(this, GameActions.rotateLeft);
            }

            if (e.KeyCode == Keys.X)
            {
                e.Handled = false;
                KeyPressed?.Invoke(this, GameActions.rotateRight);
            }

        }



        /// <summary>
        /// Метод. Обработчик для события "Нажатие копки Закрыть"
        /// </summary>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            _window.Close();
        }


        /// <summary>
        /// Метод. Обработчик для события "Нажатие копки Старт"
        /// </summary>
        private void ButtonStartClick(object sender, EventArgs e)
        {
            OnStartingGame();
        }


        /// <summary>
        /// Метод. Обработчик для события Нажатие копки "Стоп"
        /// </summary>
        private void ButtonStopClick(object sender, EventArgs e)
        {
            OnStoppingGame();
        }

        bool canClose = false;

        /// <summary>
        ///Метод. Обработчик для события Закрытие формы
        /// </summary>
        private void ViewMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose == false)
            {
                e.Cancel = true;
                OnClosingGame();
            }
        }


        /// <summary>
        ///Метод. Обработчик для события выбора пункта меню Помощь
        /// </summary>
        private void HelpToolStripMenuItemClick(object sender, EventArgs e)
        {
            KeyPressed?.Invoke(this, GameActions.help);
        }

        /// <summary>
        ///Метод. Обработчик для события выбора пункта меню Результаты
        /// </summary>
        private void RezultsToolStripMenuItemClick(object sender, EventArgs e)
        {
            KeyPressed?.Invoke(this, GameActions.showAllRezults);
        }

        /// <summary>
        ///Метод. Обработчик для события выбора пункта меню Настройки
        /// </summary>
        private void SettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            KeyPressed?.Invoke(this, GameActions.settings);
        }
    }
}
