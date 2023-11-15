using ControllerClassLibrary;
using GameActionsForAll;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using ViewInterfaces;

namespace ViewConsole
{

    /// <summary>
    /// Класс. Главный Contriller для консольного приложения
    /// </summary>
   public class ConsoleController : IViewInterfaceForController
    {
        /// <summary>
        /// Флаг показывающий идёт ли игра
        /// </summary>
        bool _isGameStarting = false;

        /// <summary>
        /// Команда введённая пользователем
        /// </summary>
        ConsoleKey _inputCommand;

        /// <summary>
        /// View
        /// </summary>
        MainView _view;


        /// <summary>
        /// Словарь доступных команд
        /// </summary>
        public Dictionary<ConsoleKey, CommandRecord> Commands { get; protected set; }

        public event EventHandler StartingGame;
        public event EventHandler StoppingGame;
        public event EventHandler ClosingGame;
        public event EventHandler<GameActions> KeyPressed;

        /// <summary>
        /// Событие, пользователь нажал клавишу
        /// </summary>
        public event EventHandler<ConsoleKeyInfo> UserKeyEntered;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="model"></param>
        public ConsoleController()
        {

            ConsoleHelper.InitConsoleWindow();

            Init();

            var model = new Model();
                _view = new MainView(model, Commands);
            var controller =
                new Controller(this, model, GetViewers);

            _view.GameIsOver += GameOver;
        }

        /// <summary>
        /// Начать работу класса
        /// </summary>
        public void Go()
        {

            while (true)
            {
                ReadUserKey();
            }
        }

        /// <summary>
        /// Метод создаёт и возвращает View запрошенного типа
        /// </summary>
        /// <param name="parType">Тип View</param>
        public object GetViewers(Type parType)
        {

            if (parType == typeof(IViewInterfaceForGameOverController))
            {
                var form = new ViewGameOverForm();

                //todo проверить  +=
                UserKeyEntered = form.GetUserCommand;

                return form;
            }


            if (parType == typeof(IViewInterfaceForShowAllRezultsController))
            {
                var form = new ViewShowAllRezults();
                UserKeyEntered = form.GetUserCommand;
                return form;
            }

            if (parType == typeof(IViewInterfaceForHelp))
            {
                var form = new ViewHelp();
                UserKeyEntered = form.GetUserCommand;
                return form;
            }

            if (parType == typeof(IViewInterfaceForSettings))
            {
                var form = new ViewSettings();
                UserKeyEntered = form.GetUserCommand;
                return form;
            }


            throw new NotSupportedException();
        }


        /// <summary>
        /// Начальная настройка
        /// </summary>
        void Init()
        {
            Commands = ConsoleCommands.CreateCommands(this);
            UserKeyEntered += ReadCommand;
        }


        

        /// <summary>
        /// Метод подписанный на событие окончания игры в Model.
        /// </summary>
        protected void GameOver(object sender, EventArgs eArg)
        {
            _isGameStarting = false;

            UserKeyEntered -= ReadCommand;

            KeyPressed?.Invoke(this, GameActions.GameOver);

            UserKeyEntered = ReadCommand;
        }


        /// <summary>
        /// Метод события. Используется для создания события "Начало игры"
        /// </summary>
        internal void OnStartingGame()
        {
            if (_isGameStarting) return;

            _isGameStarting = true;
            StartingGame?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события "Остановка игры"
        /// </summary>
        internal void OnStoppingGame()
        {
            if (!_isGameStarting) return;

            _isGameStarting = false;
            StoppingGame?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события "Закрыть игру"
        /// </summary>
        internal void OnClosingGame()
        {
            if (ClosingGame != null)
                ClosingGame.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используется для информирования подписчиков о том, что пользователь ввёл команду управления фигурой
        /// </summary>
        void OnKeyPressed(GameActions parGameAction)
        {
            KeyPressed?.Invoke(this, parGameAction);
        }


        /// <summary>
        /// Метод события. Используется для информирования подписчиков о том, что пользователь Выбрал пункт Меню
        /// </summary>
        public void OnForKeyPressed()
        {
            KeyPressed?.Invoke(this, Commands[_inputCommand]._gameAction);
        }



        /// <summary>
        /// Получить команду от пользователя
        /// </summary>
        /// <returns></returns>
        public void ReadCommand(object sender, ConsoleKeyInfo parClick)
        {
                if (parClick.Key == ConsoleKey.F10)
                {
                    Environment.Exit(0);
                }

                if (Commands.ContainsKey(parClick.Key))
                {
                    _inputCommand = parClick.Key;
                    ExecuteCommand();
                }
        }


        /// <summary>
        /// Обработка нажатия клавиши пользователем
        /// </summary>
        public void ReadUserKey()
        {
            ConsoleKeyInfo click = Console.ReadKey(true); // true, чтобы не отображать нажатую клавишу
            UserKeyEntered?.Invoke(this, click);
            if (click.Key == ConsoleKey.F10)
            {
                UserKeyEntered = ReadCommand;
                _view.RefreshWindow();
            }
        }




        /// <summary>
        /// Выполнить команду пользователя
        /// </summary>
        public void ExecuteCommand()
        {
            if (Commands[_inputCommand]._method != null) Commands[_inputCommand]._method.Invoke();
            if (_isGameStarting && Commands[_inputCommand]._gameAction != GameActions.none) 
                OnKeyPressed(Commands[_inputCommand]._gameAction);
        }
    }
}
