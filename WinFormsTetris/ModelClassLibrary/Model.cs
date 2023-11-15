using GameActionsForAll;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
//using System.Threading;
using System.Timers;
//using System.Windows.Forms;



namespace ModelClassLibrary
{
    /// <summary>
    /// Основная модель
    /// </summary>
    public class Model : IModelInterfaceForViewer, IModelInterfaceForController
    {
        /// <summary>
        /// Таймер, отвечает за движение фигуры вниз
        /// </summary>
        private System.Timers.Timer _timerMoveDown;

        /// <summary>
        /// Таймер, отвечает за обработку команд от пользователя
        /// </summary>
        private System.Timers.Timer _timerUserCommand;

        /// <summary>
        /// Действие в игре
        /// </summary>
        GameActions _currentGameAction;

        /// <summary>
        /// Флаг, игра остановлена
        /// </summary>
        bool _gameStoped = false;

        /// <summary>
        /// Задача. Движение вниз
        /// </summary>
        Task<bool> _taskMoveDown;

        /// <summary>
        /// Задача. Обработка действия
        /// </summary>
        Task<bool> _taskUserCommand;

        /// <summary>
        /// Объект используемый для синхронизации потоков
        /// </summary>
        private readonly object _toDoLock = new object();


        /// <summary>
        /// Контекст синхронизации
        /// </summary>
        public SynchronizationContext SyncContext { get; set; } // используем, чтобы события вызывались в том же потоке, 
                                                                // в котором создано окно Windows

        /// <summary>
        /// Игровое поле
        /// </summary>
        public GameBox GameBox { get; set; }



        /// <summary>
        /// Количество столбцов игровой доски
        /// </summary>
        public int BordColumns => GameBox.SettingDTO.NumberColumns;
        /// <summary>
        /// Количество строк игровой доски
        /// </summary>
        public int BordRows => GameBox.SettingDTO.NumberRows;

        /// <summary>
        /// Очки
        /// </summary>
        public int Score => GameBox.Score;

        /// <summary>
        /// Цвет фона
        /// </summary>
        public ConsoleColor BackgroundBordColor => GameBox.BackgroundBordColor;

        /// <summary>
        /// Игровая доска
        /// </summary>
        public ConsoleColor[,] GetBoard => GameBox.GetBoard();


        /// <summary>
        /// Текущая фигура
        /// </summary>
        Figure _currentFigure;




        public event EventHandler<GameBox> CreatedNewBord;
        public event EventHandler BordChanged;
        public event EventHandler ScoreChanged;
        public event EventHandler GameEnded;
        public event EventHandler CanClosingViewer;



        /// <summary>
        /// Событие для модели. Конец игре
        /// </summary>
        public event EventHandler EndGameForModel;


        /// <summary>
        /// Конструктор класса Model
        /// </summary>
        public Model()
        {
            EndGameForModel += OnGameEnded;

            GameBox = GameBox.GetInstance();
            GameBox.NewGameBoxCreated += InfoAllSubscribersNewBordCreated;


            _timerMoveDown = TimerHelper.GetNewTimer(TimerHelper.TICK_TIME_DOWN_MOVE, TimerTickMoveDown);
            _timerUserCommand = TimerHelper.GetNewTimer(TimerHelper.TICK_TIME_USER_COMMAND, TimerTickUserCommand);
        }


        /// <summary>
        /// Новая доска создана
        /// </summary>
        void InfoAllSubscribersNewBordCreated(Object obj, GameBox parGameBox)
        {
            GameBox = parGameBox;
            OnCreatedNewBord();
        }


        /// <summary>
        /// Метод, отвечающий за движение текущей фигуры вниз
        /// </summary>
        public void TimerTickMoveDown(Object source, ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)source;
            timer.Stop();

            _taskMoveDown = new Task<bool>(() => ToDo(GameActions.moveDown));
            _taskMoveDown.Start();
            bool continueGame = _taskMoveDown.Result;
            if (continueGame && !_gameStoped) timer.Start();
        }


        /// <summary>
        /// Таймер отвечающий за движение фигуры по командам от пользователя
        /// </summary>
        public void TimerTickUserCommand(Object source, ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)source;
            timer.Stop();

            _taskUserCommand = new Task<bool>(() => ToDo(_currentGameAction));
            _taskUserCommand.Start();
            bool continueGame = _taskUserCommand.Result;

            if (continueGame && !_gameStoped) timer.Start();
        }



        /// <summary>
        /// Выполнить потокобезопасное действие
        /// </summary>
        protected bool ToDo(GameActions parAction)
        {
            lock (_toDoLock)
            {
                return Action(ref _currentFigure, GameBox, parAction);
            }
        }


        /// <summary>
        /// Обработать игровое действие
        /// </summary>
        /// <param name="parFigure">Фигура</param>
        /// <param name="parGameBox">Игровое поле</param>
        /// <param name="parAction">Действие</param>
        /// <returns></returns>
        bool Action(ref Figure parFigure, GameBox parGameBox, GameActions parAction)
        {
            // Debug.Print("Action, поток: " + Thread.CurrentThread.ManagedThreadId.ToString());

            if (parFigure == null) //если фигуры не существует
            {
                parFigure = RandomFigure.GetRandomFigure(parGameBox.SettingDTO.NumberColumns);
                _currentGameAction = GameActions.none;
            }

            ConsoleColor[,] cloneBordСolors = (ConsoleColor[,])parGameBox.GetBoard().Clone(); //создаём клон поля
            Figure cloneFigure = parFigure.Clone(); //создаём клон текущей фигуры

            //стираем на клоне текущую фигуру
            ActionsOnShapes.EraseFigure(cloneFigure, cloneBordСolors, parGameBox.BackgroundBordColor);

            //перемещаем фигуру
            switch (parAction)
            {
                case GameActions.moveLeft:
                    cloneFigure.X--;
                    _currentGameAction = GameActions.none;
                    break;
                case GameActions.moveRight:
                    cloneFigure.X++;
                    _currentGameAction = GameActions.none;
                    break;
                case GameActions.moveDown:
                    cloneFigure.Y++;

                    break;
                case GameActions.dropDown:
                    break;
                case GameActions.rotateLeft:
                    cloneFigure = cloneFigure.RotateToLeft(cloneFigure);
                    _currentGameAction = GameActions.none;
                    break;
                case GameActions.rotateRight:
                    cloneFigure = cloneFigure.RotateToRight(cloneFigure);
                    _currentGameAction = GameActions.none;
                    break;
                case GameActions.none:
                    break;
                default:
                    break;
            }

            //рисуем фигуру клон на клоне картинки
            bool ok = ActionsOnShapes.DrawFigure(cloneFigure, cloneBordСolors, parGameBox.BackgroundBordColor);

            //если всё нарисовано
            if (ok)
            {
                parGameBox.DrawBord = cloneBordСolors;
                parFigure = cloneFigure;

                OnBordAndScoreChanged();
            }
            else //если нарисовать не удалось, остаётся старое поле
            {
                if (!ActionsOnShapes.CheckMoveDown(parFigure, parGameBox)) //Если движение вниз невозможно
                {
                    bool isEnable = ActionsOnShapes.CheckFullRows(parGameBox, OnBordAndScoreChanged);

                    if (!isEnable && parFigure.Y <= GameBox.Y_INDEX_WHEN_GAME_STOP) //если текущая фигура находится на верхней крайней строке
                    {
                        EndGameForModel?.Invoke(this, EventArgs.Empty); //конец игре
                        return false;
                    }
                    parGameBox.AddScore(parFigure.AddedScore); //начисляем баллы
                    parFigure = null;

                }
                else
                {
                    //SystemSounds.Beep.Play();
                }
            }
            //currentGameAction = GameActions.none;

            return true;
        }



        /// <summary>
        /// Обновление Viewer
        /// </summary>
        protected void OnBordAndScoreChanged()
        {
            Debug.Print("OnBordAndScoreChanged, вызов обновления , поток: " + Thread.CurrentThread.ManagedThreadId.ToString());

            if (SyncContext != null)
            {
                SyncContext.Send(state => BordChanged?.Invoke(this, EventArgs.Empty), null);
                SyncContext.Send(state => ScoreChanged?.Invoke(this, EventArgs.Empty), null);
            }
            else
            {
                BordChanged?.Invoke(this, EventArgs.Empty);
                ScoreChanged?.Invoke(this, EventArgs.Empty);
            }
        }





        
        /// <summary>
        /// Конец игре
        /// </summary>
        void OnGameEnded(object obj, EventArgs ea)
        {
            _timerMoveDown.Stop();
            _timerUserCommand.Stop();

            if (SyncContext != null)
            {
                SyncContext.Send(state => GameEnded?.Invoke(this, EventArgs.Empty), null);
            }
            else
            {
                GameEnded?.Invoke(this, EventArgs.Empty);
            }
        }



        /// <summary>
        /// Оповещает подписчиков, что можно закрываться
        /// </summary>
        void OnCanClosingViewer()
        {
            if (SyncContext != null)
            {
                SyncContext.Send(state => CanClosingViewer?.Invoke(this, EventArgs.Empty), null);
            }
            else
            {
                CanClosingViewer?.Invoke(this, EventArgs.Empty);
            }
        }


        


        /// <summary>
        /// Оповещаем подписчиков, что создана новыя доска
        /// </summary>
        void OnCreatedNewBord()
        {
            CreatedNewBord?.Invoke(this, GameBox);
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            _gameStoped = false;
            GameBox.SetupStartGame(GameBox);
            _currentFigure = null;
            _currentGameAction = GameActions.none;

            _timerMoveDown.Start();
            _timerUserCommand.Start();
        }

        /// <summary>
        /// Остановить игру
        /// </summary>
        public void StopGame()
        {
            _gameStoped = true;
        }

        /// <summary>
        /// Закрыть  игргу
        /// </summary>
        public void CloseGame()
        {
            _gameStoped = true;
            //taskMoveDown?.Wait();
            //taskUserCommand?.Wait();
            OnCanClosingViewer();
        }

        /// <summary>
        /// Действие, которое необходимо выполнить
        /// </summary>
        /// <param name="parAction"></param>
        public void ActionOnFigure(GameActions parAction)
        {
            _currentGameAction = parAction;
        }
    }
}
