using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;

namespace ModelClassLibrary
{
    /// <summary>
    /// Абстрактный класс, представляет фигуру
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Координата x нижнего левого угла фигуры
        /// </summary>
        private int _x;
        /// <summary>
        /// Координата y нижнего левого угла фигуры
        /// </summary>
        private int _y;
        /// <summary>
        /// Свойство. Координата Х нижнего левого угла фигуры
        /// </summary>
        public int X { get { return _x; } set { _x = value; } }
        /// <summary>
        /// Свойство. Координата Y нижнего левого угла фигуры
        /// </summary>
        public int Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Индекс функции вращения
        /// </summary>
        private int _indexRotateFunction = 0;


        /// <summary>
        /// Массив для 4-х функций отвечающих за изменение координаты нижнего левого угла фигуры при поворотах ( 4 -т.к. фигуру можно повернуть только 4 раза)
        /// </summary>
        protected dCalculateNewXYCoordinatesAfterRotateFigure[] _functionsForRotateLeft
            = new dCalculateNewXYCoordinatesAfterRotateFigure[4];

        

        /// <summary>
        /// Высота фигуры
        /// </summary>
        public int Height { get; protected set; }
        /// <summary>
        /// Ширина фигуры
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Фигура. 0-кубик не рисуется, >0 кубик закрашивается
        /// </summary>
        public int[,] mas { get; protected set; }

        /// <summary>
        /// Цвет фигуры
        /// </summary>
        public ConsoleColor Color { get; protected set; }

        /// <summary>
        /// Начисляемый балл
        /// </summary>
        public int AddedScore { get; protected set; }

        /// <summary>
        /// Делегат на функцию, которая вычисляет новые значения для координат X и Y при повороте фигуры влево (против часовой стрелки)
        /// </summary>
        protected delegate void dCalculateNewXYCoordinatesAfterRotateFigure(ref int x, ref int y);


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parBordColumns">Ширина доски </param>
        /// <param name="parAddedScore">Начисляемы балл</param>
        /// <param name="parColor">Цвет фигуры</param>
        /// <param name="parMas">Массив звдвющий фигуру</param>
        protected Figure(int parBordColumns, int parAddedScore, ConsoleColor parColor, int[,] parMas)
        {
            Height = parMas.GetLength(0);
            Width = parMas.GetLength(1);
            this.mas = parMas;
            this.Color = parColor;
            this.AddedScore = parAddedScore;

            Y = -1;
            X= parBordColumns / 2 - Width / 2;
        }



        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns></returns>
       public Figure Clone()
        {
            return (Figure)this.MemberwiseClone();
        }



        /// <summary>
        /// Поворот фигуры в правую сторону
        /// </summary>
        /// <param name="parFigure">Исходная фигура</param>
        /// <returns>Новая фигуря, повёрнутая относительно исходной на 90 градусов в правую сторону</returns>
        public Figure RotateToRight(Figure parFigure)
        {
            Figure newf = parFigure.Clone();

            for (int i = 0; i < 3; i++)   //поварачиваем фигуру в левую сторону 3 раза
            {
                newf = RotateToLeft(newf);
            }
            return newf;
        }

        /// <summary>
        /// Поворот фигуры в левую сторону
        /// </summary>
        /// <param name="parFigure">Исходная фигура</param>
        /// <returns>Новая фигуря, повёрнутая относительно исходной на 90 градусов в левую сторону</returns>
        public Figure RotateToLeft(Figure parFigure)
        {
            Figure newf = parFigure.Clone();

            newf.Width = parFigure.Height;
            newf.Height = parFigure.Width;
            newf.mas = new int[newf.Height, newf.Width];

            for (int i = 0; i < parFigure.Height; i++)
            {
                for (int j = 0; j < parFigure.Width; j++)
                {
                    newf.mas[newf.Height - 1 - j, i] = parFigure.mas[i, j];
                }
            }


            _functionsForRotateLeft[parFigure._indexRotateFunction](ref newf._x, ref newf._y);
            newf._indexRotateFunction = parFigure._indexRotateFunction<3?++parFigure._indexRotateFunction:0;

            return newf;
        }
    }


   
    /// <summary>
    /// Фигура I
    /// </summary>
    class FigureI : Figure
    {
        public FigureI(int parX) : base(parX, 2, ConsoleColor.Cyan, new int[1, 4] { { 1, 1, 1, 1 } })
        {
            
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x+=2; y++; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x-=2; y-=2; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x++; y+=2; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x--; y--; };
        }
    }

    /// <summary>
    /// Фигура J
    /// </summary>
    class FigureJ : Figure
    {
        public FigureJ(int parX) : base(parX, 3, ConsoleColor.Blue, new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x ++; y+=0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x --; y --; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x+=0; y ++; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x+=0; y+=0; };
        }
    }

    /// <summary>
    /// Фигура L
    /// </summary>
    class FigureL : Figure
    {
        public FigureL(int parX) : base(parX, 3, ConsoleColor.DarkYellow, new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x++; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x--; y--; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y++; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };

        }
    }

    /// <summary>
    /// Фигура O
    /// </summary>
    public class FigureO:Figure
    {
      public FigureO(int parX) :base(parX, 2, ConsoleColor.Yellow, new int[2, 2] { { 1, 1 }, { 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };
        }
    }

    /// <summary>
    /// Фигура S
    /// </summary>
    class FigureS : Figure
    {
        public FigureS(int parX) : base(parX, 4, ConsoleColor.Green, new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 1; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 1; y -= 1; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 1; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };

        }
    }

    /// <summary>
    /// Фигура T
    /// </summary>
    class FigureT : Figure
    {
        public FigureT(int parX) : base(parX, 4, ConsoleColor.Magenta, new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 1; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 1; y -= 1; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 1; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };

        }
    }

    /// <summary>
    /// Фигура Z
    /// </summary>
    class FigureZ : Figure
    {
        public FigureZ(int parX) : base(parX, 4, ConsoleColor.Red, new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 1; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 1; y -= 1; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 1; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };

        }
    }


    //-------------------------- НЕстандартные фигуры-------------------------------

    /// <summary>
    /// Фигура P
    /// </summary>
    class FigureP : Figure
    {
        public FigureP(int parX) : base(parX, 6, ConsoleColor.DarkGreen, new int[2, 3] { { 1, 0, 1 }, { 1, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 1; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 1; y -= 1; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 1; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };
        }
    }

    /// <summary>
    /// Фигура T2
    /// </summary>
    class FigureT2 : Figure
    {
        public FigureT2(int parX) : base(parX, 7, ConsoleColor.DarkBlue, new int[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 1, 1, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 0; y -= 0; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };
        }
    }


    /// <summary>
    /// Фигура N2
    /// </summary>
    class FigureN2 : Figure
    {
        public FigureN2(int parX) : base(parX, 8, ConsoleColor.DarkMagenta, new int[3, 3] { { 1, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 } })
        {
            _functionsForRotateLeft[0] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[1] = (ref int x, ref int y) => { x -= 0; y -= 0; };
            _functionsForRotateLeft[2] = (ref int x, ref int y) => { x += 0; y += 0; };
            _functionsForRotateLeft[3] = (ref int x, ref int y) => { x += 0; y += 0; };
        }
    }




    /// <summary>
    /// Интерфейс фабрики
    /// </summary>
    interface IFugureFactory
    {
        /// <summary>
        /// Создать фигуру
        /// </summary>
        /// <param name="parBordColumns">Количество столбцов игровой доски</param>
        /// <returns></returns>
       public Figure CreateFigure(int parBordColumns);
    }


    /// <summary>
    /// Класс, сощдающий фигуру I
    /// </summary>
    class FactoryFigureI : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureI(parBordColumns);
        }
    }


    /// <summary>
    /// Класс, сощдающий фигуру J
    /// </summary>
    class FactoryFigureJ : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureJ(parBordColumns);
        }
    }


    /// <summary>
    /// Класс, сощдающий фигуру L
    /// </summary>
    class FactoryFigureL : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureL(parBordColumns);
        }
    }


    /// <summary>
    /// Класс, сощдающий фигуру O
    /// </summary>
    class FactoryFigureO :IFugureFactory
    {
        public  Figure CreateFigure(int parBordColumns)
        {
            return new FigureO(parBordColumns);
        }
    }

    /// <summary>
    /// Класс, сощдающий фигуру S
    /// </summary>
    class FactoryFigureS : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureS(parBordColumns);
        }
    }


    /// <summary>
    /// Класс, сощдающий фигуру T
    /// </summary>
    class FactoryFigureT : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureT(parBordColumns);
        }
    }


    /// <summary>
    /// Класс, сощдающий фигуру Z
    /// </summary>
    class FactoryFigureZ : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureZ(parBordColumns);
        }
    }


    //-------НЕстандартные фигуры
    /// <summary>
    /// Класс, сощдающий фигуру P
    /// </summary>
    class FactoryFigureP : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureP(parBordColumns);
        }
    }

    /// <summary>
    /// Класс, сощдающий фигуру T2
    /// </summary>
    class FactoryFigureT2 : IFugureFactory
    {
        public Figure CreateFigure(int parBordColumns)
        {
            return new FigureT2(parBordColumns);
        }
    }

    /// <summary>
    /// Класс, сощдающий фигуру N2
    /// </summary>
    class FactoryFigureN2 : IFugureFactory
    {
        public Figure CreateFigure(int aprBordColumns)
        {
            return new FigureN2(aprBordColumns);
        }
    }
}
