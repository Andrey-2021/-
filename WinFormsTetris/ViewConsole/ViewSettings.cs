using GameActionsForAll;
using ModelHelper;
using System;
using ViewInterfaces;

namespace ViewConsole
{
    /// <summary>
    /// Класс. Представляет окно с настройками
    /// </summary>
    class ViewSettings : IViewInterfaceForSettings
    {
        /// <summary>
        /// Ширина окна
        /// </summary>
        static readonly int _width = 65;

        /// <summary>
        /// Высота окна
        /// </summary>
        static readonly int _height = 30;

        /// <summary>
        /// Координата Х верхнего левого угла окна
        /// </summary>
        readonly int _startX = (Console.WindowWidth - _width) / 2;

        /// <summary>
        /// Координата Y верхнего левого угла окна
        /// </summary>
        readonly int _startY = (Console.WindowHeight - _height) / 2;

        /// <summary>
        /// Model
        /// </summary>
        ISettingsModel _model;

        /// <summary>
        /// Текущие настройки игры
        /// </summary>
        SettingDTO _currentSettingDTO = null;

        public event EventHandler<SettingDTO> NewSettingInstalledInView;

        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow(Object obj, EventArgs args)
        {
            ShowView();
        }

        /// <summary>
        /// Отрисовать View
        /// </summary>
        public void ShowView()
        {
            ConsoleHelper.DrawWindow(_startX, _startY, _height, _width);
            SetControlsOnForm(_model.GetSetting());
        }



        public void SetModel(ISettingsModel parModel)
        {
            this._model = parModel;
            parModel.ShowNewWindow += ShowWindow;
        }


        /// <summary>
        /// Получить команду от пользователя
        /// </summary>
        public void GetUserCommand(object sender, ConsoleKeyInfo parClick)
        {

            if (parClick.Key == ConsoleKey.F1) //Установка новых настроек пользователя
            {
                OnNewSettingInstalledInView(_currentSettingDTO);
                //-break;
            }

            if (parClick.Key == ConsoleKey.F10)
            {
                //-break;// Выход без сохранения настроек
            }

            var ch = parClick.KeyChar;

            if (byte.TryParse(ch.ToString(), out byte n))
            {
                switch (n)
                {
                    case 1:
                        if (_currentSettingDTO.NumberRows < _currentSettingDTO.MaxRows)
                        {
                            _currentSettingDTO.NumberRows++;
                            SetControlsOnForm(_currentSettingDTO);
                        }
                        else Console.Beep();
                        break;
                    case 2:
                        if (_currentSettingDTO.NumberRows > _currentSettingDTO.MinRows)
                        {
                            _currentSettingDTO.NumberRows--;
                            SetControlsOnForm(_currentSettingDTO);
                        }
                        else Console.Beep();
                        break;
                    case 3:
                        if (_currentSettingDTO.NumberColumns < _currentSettingDTO.MaxColumns)
                        {
                            _currentSettingDTO.NumberColumns++;
                            SetControlsOnForm(_currentSettingDTO);
                        }
                        else Console.Beep();
                        break;
                    case 4:
                        if (_currentSettingDTO.NumberColumns > _currentSettingDTO.MinColumns)
                        {
                            _currentSettingDTO.NumberColumns--;
                            SetControlsOnForm(_currentSettingDTO);
                        }
                        else Console.Beep();
                        break;
                    case 5:
                        _currentSettingDTO.IsClassicFigureMode = false;
                        SetControlsOnForm(_currentSettingDTO);
                        break;
                    case 6:
                        _currentSettingDTO.IsClassicFigureMode = true;
                        SetControlsOnForm(_currentSettingDTO);
                        break;


                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// обновить
        /// </summary>
        void RefreshView(object obj, SettingDTO parSettingDTO)
        {
            SetControlsOnForm(parSettingDTO);
        }

        /// <summary>
        /// Оповестить подписчиков об установке новых настроек
        /// </summary>
        void OnNewSettingInstalledInView(SettingDTO parSettingDTO)
        {
            NewSettingInstalledInView?.Invoke(this, parSettingDTO);
            Console.Beep();
        }


        /// <summary>
        /// Настройка элементов на форме
        /// </summary>
        /// <param name="parSettingDTO">Текущие настройки</param>
        void SetControlsOnForm(SettingDTO parSettingDTO)
        {
            _currentSettingDTO = parSettingDTO;

            const int dx = 10;
            int dy = 2;

            ConsoleHelper.ClearArea(_startX + 1, _startY + 1, _height - 2, _width - 2);

            string strTitle = "Настройки игры";
            Console.SetCursorPosition(_startX + (_width - strTitle.Length) / 2, _startY + dy);
            Console.Write(strTitle);



            dy += 2;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("Количество строк (от " + parSettingDTO.MinRows
                + " до " + parSettingDTO.MaxRows + ")");
            dy += 2;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("Текущее значение: " + parSettingDTO.NumberRows);
            dy += 1;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("1 - Увеличить значение на +1 ");
            dy += 1;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("2 - Уменьшить значение на -1 ");




            dy += 4;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("Количество столбцов (от " + parSettingDTO.MinColumns
                + " до " + parSettingDTO.MaxColumns + ")");
            dy += 2;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("Текущее значение: " + parSettingDTO.NumberColumns);
            dy += 1;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("3 - Увеличить значение на +1 ");
            dy += 1;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("4 - Уменьшить значение на -1 ");



            dy += 4;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            Console.Write("Набор фигур: ");

            dy += 1;
            Console.SetCursorPosition(_startX + dx, _startY + dy);
            if (parSettingDTO.IsClassicFigureMode)
            {
                Console.Write("Стандартный набор фигур");
                dy += 1;
                Console.SetCursorPosition(_startX + dx, _startY + dy);
                Console.Write("5 - Переключиться на расширенный набор фигур  ");

            }
            else
            {
                Console.Write("Расширенный набор фигур");
                dy += 1;
                Console.SetCursorPosition(_startX + dx, _startY + dy);
                Console.Write("6 - Переключиться на стандартный набор фигур  ");
            }


            string str = "F1 - Сохранить настройка        F10-Выход";
            Console.SetCursorPosition(_startX + (_width - str.Length) / 2, _startY + _height - 4);
            Console.Write(str);
        }
    }
}
