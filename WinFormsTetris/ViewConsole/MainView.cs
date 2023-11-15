using GameActionsForAll;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewConsole
{
    /// <summary>
    /// Класс. Главный View Игры
    /// </summary>
    class MainView
    {
        /// <summary>
        /// Model
        /// </summary>
        readonly IModelInterfaceForViewer _model;


        /// <summary>
        /// Словарь доступных команд
        /// </summary>
        public Dictionary<ConsoleKey, CommandRecord> Commands { get; protected set; }

        /// <summary>
        /// Объект используемый для синхронизации потоков
        /// </summary>
        private readonly object _toDoLock = new object();

                /// <summary>
        /// Событие. Конец игре
        /// </summary>
        public event EventHandler GameIsOver;

        

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainView(IModelInterfaceForViewer parModel, Dictionary<ConsoleKey, CommandRecord> parCommands)
        {
            this._model = parModel;
            this.Commands = parCommands;
            Init();
        }

        /// <summary>
        /// Начальная настройка
        /// </summary>
        void Init()
        {
            RefreshWindow();
            InitModel();
        }

        /// <summary>
        /// Подписываемся на события модели
        /// </summary>
        void InitModel()
        {
            _model.ScoreChanged += RevreshScore;
            _model.BordChanged += RefreshBoard;
            _model.GameEnded += GameOver;
        }


        /// <summary>
        /// Перерисовывем всё окно
        /// </summary>
        public void RefreshWindow()
        {
            //todo синхрон потоков
            lock (_toDoLock)
            {
                Console.ResetColor();
                Console.Clear();
                ConsoleMessagesWindows.ShowGameCommands(this);

                RefreshBoard(this, EventArgs.Empty);
                RevreshScore(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Обновляем изображение игрового поля
        /// </summary>
        void RefreshBoard(object sender, EventArgs ea)
        {
            var colors = _model.GetBoard;

            int widthForShowCommands = ConsoleMessagesWindows._xGameCommandsList + ConsoleMessagesWindows._widthGameCommandsList;

            int x = Console.WindowWidth - widthForShowCommands - colors.GetLength(1) * ConsoleHelper._kol; //Ширина доски

            ConsoleHelper.ShowBorder(widthForShowCommands + x / 2 - 1, 3 - 1, ConsoleHelper._kol * colors.GetLength(1) + 2, ConsoleHelper._kol / 2 * colors.GetLength(0) + 2);
            ConsoleHelper.ShowBord(colors, widthForShowCommands + x / 2, 3);

        }

        /// <summary>
        /// Обновляем счёт
        /// </summary>
        void RevreshScore(object sender, EventArgs ea)
        {
            ConsoleMessagesWindows.ShowScore(_model.Score);
        }



        /// <summary>
        /// Метод подписанный на событие окончания игры в Model.
        /// </summary>
        protected void GameOver(object sender, EventArgs eArg)
        {
            GameIsOver?.Invoke(this, EventArgs.Empty);

            //обновить экран
            RefreshWindow();
        }
    }
}
