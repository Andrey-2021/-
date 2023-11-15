using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    /// <summary>
    /// Создание случайной фигуры
    /// </summary>
    class RandomFigure
    {

        /// <summary>
        /// Получить список фабрик фигур
        /// </summary>
        /// <returns>Список фабрик</returns>
        static List<IFugureFactory> GetFactoriesLists()
        {
            List<IFugureFactory> FiguresFactories = new List<IFugureFactory>();

            FiguresFactories.Add(new FactoryFigureI());
            FiguresFactories.Add(new FactoryFigureJ());
            FiguresFactories.Add(new FactoryFigureL());
            FiguresFactories.Add(new FactoryFigureO());
            FiguresFactories.Add(new FactoryFigureS());
            FiguresFactories.Add(new FactoryFigureT());
            FiguresFactories.Add(new FactoryFigureZ());

            return FiguresFactories;
        }
       
        /// <summary>
        /// Получаем список фабрик для дополнительных фигур
        /// </summary>
        /// <returns></returns>
        static List<IFugureFactory> GetAdvancedFiguresFactoriesLists()
        {
            List<IFugureFactory> FiguresFactories = new List<IFugureFactory>();
            FiguresFactories.Add(new FactoryFigureP());
            FiguresFactories.Add(new FactoryFigureT2());
            FiguresFactories.Add(new FactoryFigureN2());
            return FiguresFactories;
        }



        /// <summary>
        /// Получить случайную фигуру
        /// </summary>
        /// <param name="parBordColumns">Ширина игрового поля. Используется для вычисления координаты Х создаваемой фигуры</param>
        /// <returns>Случайная фигура</returns>
        public static Figure GetRandomFigure(int parBordColumns)
        {
            Random rnd = new Random();

            List<IFugureFactory> FigureFactories = GetFactoriesLists();
            if (GameBox.GetInstance().SettingDTO.IsClassicFigureMode == false) FigureFactories.AddRange(GetAdvancedFiguresFactoriesLists());

            int n = rnd.Next(0, FigureFactories.Count);        //получаем случайное число
            IFugureFactory fugureFactory = FigureFactories[n]; //и бывираем фабрику с номером n из списка доступных фабрик

            return fugureFactory.CreateFigure(parBordColumns);
        }
    }
}
