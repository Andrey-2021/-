using GameActionsForAll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{

    /// <summary>
    /// Игровое поле
    /// </summary>
   public class GameBox
    {

        /// <summary>
        ///Значение Y координаты падающей фигуры, при которой игра останавливается, если движение вниз невозможно 
        /// </summary>
        public const int Y_INDEX_WHEN_GAME_STOP = 0;

        /// <summary>
        /// Очки за полные строчки. За каждую следующую, подряд идущую полную строчку, добавляется больше очков. 
        /// </summary>
        public static int[] _fullRowScore = { 50, 100, 150, 200, 250, 300 };

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static GameBox _instance;

        /// <summary>
        /// Цвет фона
        /// </summary>
        public ConsoleColor BackgroundBordColor { get; } = ConsoleColor.White;
        /// <summary>
        /// Цвет полной строки
        /// </summary>
        public ConsoleColor FullRowColor { get; } = ConsoleColor.Gray;

        /// <summary>
        /// Массив цветов представляющий игровое поле
        /// </summary>
        public ConsoleColor[,] DrawBord { get; set; }

        /// <summary>
        /// Настройки игрового поля
        /// </summary>
        public SettingDTO SettingDTO { get; protected set; }

        /// <summary>
        /// Очки
        /// </summary>
        public int Score { get; protected set; }



        /// <summary>
        /// Событие. Создана новая доска
        /// </summary>
        public event EventHandler<GameBox> NewGameBoxCreated;


       

        /// <summary>
        /// Конструктор
        /// </summary>
        private GameBox()
        {
            SettingDTO settingDTO = new SettingDTO()
            {
                NumberRows = 12,
                NumberColumns = 8,
                IsClassicFigureMode = true
            };
            CreateNewBord(settingDTO);
        }

        /// <summary>
        /// Получить игровое поле 
        /// </summary>
        /// <returns></returns>
        public ConsoleColor[,] GetBoard()
        {
            return DrawBord;
        }

        /// <summary>
        /// Получить экземпляр класса
        /// </summary>
        /// <returns></returns>
        public static GameBox GetInstance()
        {
            if (_instance == null)
                _instance = new GameBox();
            return _instance;
        }



        /// <summary>
        ///  Создать новую доску
        /// </summary>
        public void CreateNewBord(SettingDTO parSettingDTO)
        {
            SettingDTO = parSettingDTO;
            DrawBord = new ConsoleColor[SettingDTO.NumberRows, SettingDTO.NumberColumns];

            ClearBord(DrawBord);
            OnNewGameBoxCreated();
        }

        /// <summary>
        /// Сообщить подписчикам, что создана новая доска
        /// </summary>
         void OnNewGameBoxCreated()
        {
            NewGameBoxCreated?.Invoke(this, this);
        }


        /// <summary>
        /// Очистить доску
        /// </summary>
        void ClearBord(ConsoleColor[,] parBordСolors)
        {
            
            int nRows = parBordСolors.GetLength(0);
            int nColumns = parBordСolors.GetLength(1);

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    parBordСolors[i, j] = BackgroundBordColor;
                }
            }
        }

        /// <summary>
        /// Настройка перед началом игры
        /// </summary>
        public void SetupStartGame(GameBox parGameBord)
        {
            ConsoleColor[,] bord = parGameBord.GetBoard();
            ClearBord(bord);
            parGameBord.Score = 0;
        }

        /// <summary>
        /// Добавить очки к результату
        /// </summary>
        /// <param name="parN"></param>
        public void AddScore(int parN)
        {
            Score += parN;
        }
    }
}
