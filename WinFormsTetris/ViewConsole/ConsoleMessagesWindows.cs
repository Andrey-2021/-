using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{

    /// <summary>
    /// Класс, содержит методы для вывода информационных блоков в консольном приложении
    /// </summary>
    class ConsoleMessagesWindows
    {
        /// <summary>
        /// ширина окна со списком команд
        /// </summary>
        public const int _widthGameCommandsList = 25;

        /// <summary>
        /// координата Х верхнего левого угла
        /// </summary>
        public const int _xGameCommandsList = 3;
        /// <summary>
        /// координата Y верхнего левого угла
        /// </summary>
        public const int _yGameCommandsList = 2;


        /// <summary>
        /// Координата Y, верхнего левого угла окна для выволда набранных очков
        /// </summary>
        static int _yScore = 19; 
        

        /// <summary>
        /// Выводим на экран количество набранных очков
        /// </summary>
        /// <param name="parScore">Очки</param>
        public static void ShowScore(int parScore)
        {
            //высота окна
            const int scoreHeight = 5;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            String clearStr = new string(' ', _widthGameCommandsList);

            const string message = "Очков: ";
            const int dx = 3;
            Console.SetCursorPosition(_xGameCommandsList, _yScore+scoreHeight/2);
            Console.Write(clearStr); //очистили строку от старых результатов

            Console.SetCursorPosition(_xGameCommandsList + dx, _yScore + scoreHeight / 2);
            Console.Write(message + parScore);

            
            ConsoleHelper.ShowBorder(_xGameCommandsList, _yScore, _widthGameCommandsList, scoreHeight);
        }


 



        /// <summary>
        /// Вывод списка доступных команд
        /// </summary>
        public static void ShowGameCommands(MainView parView)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            int dx = 2; //внутренний отступ от рамки

            //int maxStringLength = 0; //длина строки
            int i = 1;
            
            Console.SetCursorPosition(_xGameCommandsList + dx, _yGameCommandsList +  i);
            Console.Write("Клавиши управления");

            i+=2;
            foreach (var item in parView.Commands.Values)
            {
                Console.SetCursorPosition(_xGameCommandsList + dx, _yGameCommandsList + i);
                Console.Write(item._name);
                i++;
            }

            ConsoleHelper.ShowBorder(_xGameCommandsList, _yGameCommandsList, _widthGameCommandsList, _yGameCommandsList + i );
            _yScore = _yGameCommandsList + i + 2;
        }



        /// <summary>
        /// Очистка места
        /// </summary>
        /// <param name="parX">X-координата левого верхнего угла</param>
        /// <param name="parY">Y-координата левого верхнего угла</param>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        static void ClearPlace(int parX, int parY, int parWidth,  int parHeight)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = parY; i < parY+parHeight; i++)
            {
                for (int j = parX; j < parX+parWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');

                }
            }
        }
    }
}
