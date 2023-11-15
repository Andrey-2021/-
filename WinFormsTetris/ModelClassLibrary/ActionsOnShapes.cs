using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    /// <summary>
    /// Действия с фигурами
    /// </summary>
    class ActionsOnShapes
    {
        /// <summary>
        /// Стереть(очистить элементы) фигуру с доски(матрицы)
        /// </summary>
        /// <param name="parFigure"></param>
        /// <param name="gameBord"></param>
        public static void EraseFigure(Figure parFigure, ConsoleColor[,] parBord, ConsoleColor parBackgroundBordColor)
        {
            Draw(parFigure, parBord, WhatToDoWithFigure.erase, parBackgroundBordColor);
        }

        /// <summary>
        /// Наложить фигуру на доску(матрицу)
        /// </summary>
        public static bool DrawFigure(Figure parFigure, ConsoleColor[,] parBord, ConsoleColor parBackgroundBordColor)
        {
           return Draw(parFigure, parBord, WhatToDoWithFigure.draw,  parBackgroundBordColor);
        }


        /// <summary>
        /// накладываем фигуру на новом месте доски(матрице) ИЛИ "стираем"(очищаем жлементы) "старую" фигуру, т.е. фигуру на предыдущем месте
        /// </summary>
        static bool Draw(Figure parFigure, ConsoleColor[,] parBord, WhatToDoWithFigure parDrawingOrCleaning, ConsoleColor parBackgroundBordColor)
        {

            if(parDrawingOrCleaning==WhatToDoWithFigure.draw)
            {
                if (parFigure.X < 0                                        //если левая часть оказалась за доской
                    || parFigure.X + parFigure.Width > parBord.GetLength(1)// gameBord.BordColumns  //ИЛИ правая часть фигуры оказалась за доской
                    || parFigure.Y >= parBord.GetLength(0)                                         // ИЛИ ниже доски
                    || parFigure.Y <0                                      // ИЛИ выше доски
                    ) return false;
            }

            for (int i = 0; i < parFigure.Height; i++) //цикл по строкам фигуры
            {
                if ((parFigure.Y < 0) || (parFigure.Y - (parFigure.Height - 1) + i < 0)) continue; //не выводим верхнюю часть фигуры, если она не влазит в экран

                for (int j = 0; j < parFigure.Width; j++) //цикл по столбцам фигуры
                {
                    if (parFigure.mas[i, j] > 0)
                    {
                        if (parDrawingOrCleaning == WhatToDoWithFigure.draw)
                        {
                            //если окажется, что ячейка непустая, значит нарисовать фигуру невозможно
                            if (parBord[parFigure.Y - (parFigure.Height - 1) + i, parFigure.X + j] != parBackgroundBordColor) return false;

                            parBord[parFigure.Y - (parFigure.Height - 1) + i, parFigure.X + j] = parFigure.Color;
                        }

                        if (parDrawingOrCleaning == WhatToDoWithFigure.erase)
                            parBord[parFigure.Y - (parFigure.Height - 1) + i, parFigure.X + j] = parBackgroundBordColor;
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// Проверка, может ли фигура упасть на один ряд вниз
        /// </summary>
        /// <param name="parFigure"></param>
        /// <param name="pagGameBord"></param>
        /// <returns>tru-если движение вниз на одну клетку возможно, false - движение вниз невозможно</returns>
        public static bool CheckMoveDown(Figure parFigure, GameBox pagGameBord)
        {
            //если фигура находится на самой нижней строчке поля
            if (parFigure.Y == pagGameBord.SettingDTO.NumberRows - 1) return false;

            ConsoleColor[,] bord = pagGameBord.GetBoard();

            for (int i = 0; i < parFigure.Height; i++)
            {
                int y = parFigure.Height - 1 - i;

                if (parFigure.Y - (parFigure.Height - 1 - i) < -1) continue; //не выводим верхнюю часть фигуры, если она не влазит в экран,
                                                                       //кроме нижней строчки(поэтому <-1, т.к. нам надо проверить может ли фигура появиться на экране)

                for (int j = 0; j < parFigure.Width; j++)
                {
                    //если это последняя строчка фигуры ИЛИ (непоследняя строчка, но/и ниже клетка незанята самой текущей фигурой  )
                    if ((i == parFigure.Height - 1 || (i < parFigure.Height - 1 && parFigure.mas[i + 1, j] == 0))
                        // если текущая клетка в фигуре закрашена И клетка (поля) ниже закрашенна ,тогда движение невозможно
                        && (parFigure.mas[i, j] > 0 && bord[parFigure.Y - (parFigure.Height - 1) + 1 + i, parFigure.X + j] != pagGameBord.BackgroundBordColor))

                    {
                        return false;
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// Поиск полной строки
        /// </summary>
        /// <returns>Индекс полной строки или -1, если нет заполненой строки</returns>
        
        public static int FindFullRow(GameBox parGameBox)
        {
            for (int i = parGameBox.SettingDTO.NumberRows - 1; i >= 0; i--)
            {
                bool isBackgroundColor = false;

                for (int j = 0; j <parGameBox.SettingDTO.NumberColumns; j++)
                {

                    if (parGameBox.DrawBord[i, j] == parGameBox.BackgroundBordColor)
                    {
                        isBackgroundColor = true;
                        break;
                    }
                }
                if (!isBackgroundColor) return i;
            }
            return -1;
        }



        /// <summary>
        /// Проверка полных строк
        /// </summary>
        /// <param name="parGameBox"></param>
        /// <returns>true-если были полные строки, false-если полных строк нет</returns>
        public static bool CheckFullRows(GameBox parGameBox, Action parNeedRefreshViewer)
        {
            int pauseBetweenShows = 500; //пауза между показами обновлённой картинки пользователю
            int countFullRow = 0; // счётчик подряд заполненых строк
            bool isEnable = false; // признак что есть заполненая строка
            int n; //индекс заполненой строки

            while ((n = ActionsOnShapes.FindFullRow(parGameBox)) >= 0)
            {
                parGameBox.AddScore(GameBox._fullRowScore[countFullRow]); //начислили очки за строчку
                countFullRow++;

                DrawLine(parGameBox, parGameBox.FullRowColor, n);
                parNeedRefreshViewer();
                Thread.Sleep(pauseBetweenShows);

                MovePictureDownOnOneRow(parGameBox, n);
                parNeedRefreshViewer();
                Thread.Sleep(pauseBetweenShows);
                isEnable = true;
            };
            return isEnable;
        }


        /// <summary>
        /// Закрашиваем строку игрового поля заданным цветом
        /// </summary>
        /// <param name="parGameBox">Игровая доска</param>
        /// <param name="parColor">Цвет закраски</param>
        /// <param name="parN">Индекс строки</param>
       static void DrawLine(GameBox parGameBox, ConsoleColor parColor, int parN)
        {
            for (int j = 0; j < parGameBox.SettingDTO.NumberColumns; j++)
            {
                parGameBox.DrawBord[parN, j] = parColor;
            }
        }


        /// <summary>
        /// Сдвигаем все строки матрицы(доски) выше заполненой строки вниз
        /// </summary>
        /// <param name="parGameBox"></param>
        /// <param name="parN">Индекс полной строки</param>
        static void MovePictureDownOnOneRow(GameBox parGameBox, int parN)
        {
            for (int i = parN; i > 0; i--)
            {
                for (int j = 0; j < parGameBox.SettingDTO.NumberColumns; j++)
                {
                    parGameBox.DrawBord[i, j] = parGameBox.DrawBord[i - 1, j];
                }
            }

            DrawLine(parGameBox, parGameBox.BackgroundBordColor, 0); //очищаем нулевую строчку (самую верхнюю)
        }
    }
}
