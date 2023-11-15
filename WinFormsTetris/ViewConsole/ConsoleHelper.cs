using System;

namespace ViewConsole
{
    /// <summary>
    /// Класс содержит вспомогательные методы для консольного приложения
    /// </summary>
    class ConsoleHelper
    {
        /// <summary>
        /// Количество знакомест экрана на квадрат фигуры
        /// </summary>
        public const int _kol = 4;

        /// <summary>
        /// Обновляем изображение доски
        /// </summary>
        /// <param name="prBord">Игровое поле</param>
        /// <param name="parX0">X-координата верхнего левого угла игрового поля</param>
        /// <param name="parY0">Y-координата верхнего левого угла игрового поля</param>
        public static void ShowBord(ConsoleColor[,] prBord, int parX0, int parY0)
        {
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ResetColor();


            for (int i = 0; i < prBord.GetLength(0); i++)
            {
                for (int j = 0; j < prBord.GetLength(1); j++)
                {
                    try
                    {
                        //два цикла для создания "клетки" игрового поля,
                        //которая представялет собой прямоугольник/квадрат состоящая из KOL*(KOL/2) символов консоли
                        // Цель - сделать игровые клетки крупнее
                        
                        for (int m = 0; m < _kol / 2; m++)  
                        {
                            for (int n = 0; n < _kol; n++)
                            {
                                Console.SetCursorPosition(parX0 + j * _kol + n, parY0 + i * (_kol / 2) + m);
                                Console.BackgroundColor = prBord[i, j];

                                Console.Write("\u2591");
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
        





        /// <summary>
        /// Настройка окна консоли
        /// </summary>
        public static void InitConsoleWindow()
        {
            Console.WindowWidth = 90;
            Console.WindowHeight = 35;
            
            Console.BufferWidth = 90;
            Console.BufferHeight = 35;


            //Console.CursorSize = 1;
            Console.CursorVisible = false;
            Console.Title = "Тетрис";

            Console.ResetColor();
            Console.Clear();
        }




        /// <summary>
        /// Нарисовать рамку
        /// </summary>
        /// <param name="parX">Х-координата верхнего левого угла</param>
        /// <param name="parY">Y-координата верхнего левого угла</param>
        /// <param name="parWidth">Ширина рамки</param>
        /// <param name="parHeight">Высота рамки</param>
        /// Кодировка CP866
        /// https://ru.wikipedia.org/wiki/CP866
        public static void ShowBorder(int parX, int parY, int parWidth, int parHeight)
        {
            for (int i = parX+1; i < parX+parWidth; i++)
            {
                Console.SetCursorPosition(i, parY);  //верхняя горизонтальная линия
                Console.Write((char)0x2550);
                
                Console.SetCursorPosition(i, parY+parHeight-1); //нижняя горизонтальная линия
                Console.Write((char)0x2550);
            }

           
            for (int i = parY + 1; i < parY + parHeight; i++)
            {
                Console.SetCursorPosition(parX, i);  //левая вертикальная линия
                Console.Write((char)0x2551);

                Console.SetCursorPosition(parX+parWidth-1,i); //правая вертикальная линия
                Console.Write((char)0x2551);
            }

            //углы
            Console.SetCursorPosition(parX, parY); 
            Console.Write((char)0x2554);

            Console.SetCursorPosition(parX+parWidth-1, parY);
            Console.Write((char)0x2557);

            Console.SetCursorPosition(parX, parY+parHeight-1);
            Console.Write((char)0x255A);

            Console.SetCursorPosition(parX+parWidth-1, parY+parHeight-1);
            Console.Write((char)0x255D);
        }



        /// <summary>
        /// Нарисовать окно
        /// </summary>
       public static void DrawWindow(int parStartX, int parStartY, int parHeight, int parWidth)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ClearArea(parStartX, parStartY, parHeight, parWidth);
            ConsoleHelper.ShowBorder(parStartX, parStartY, parWidth, parHeight);
        }

        /// <summary>
        /// Очистить площадь окна
        /// </summary>
       public static void ClearArea(int parX, int parY, int parHeight, int parWidth)
        {
            for (int i = 0; i < parHeight; i++)
            {
                for (int j = 0; j < parWidth; j++)
                {
                    Console.SetCursorPosition(parX + j, parY + i);
                    Console.BackgroundColor = ConsoleColor.Blue; // GameBox.GetInstance().BackgroundBordColor;
                    Console.Write(' ');
                }
            }
        }

    }
}
