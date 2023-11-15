using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Тесты для тестирования класса GameRezultDTO
    /// </summary>
    [TestFixture]
    public class GameRezultDTOTest
    {
        string name = "Петров";
        int score = 123;
        DateTime dateTime = new DateTime(1987, 11, 9);

        GameRezultDTO gameRezult;

        /// <summary>
        /// Создание объекта перед запуском каждго теста
        /// </summary>
        [SetUp]
        public void CreateDTO()
        {
            gameRezult = new GameRezultDTO() { Name=name, Score=score, DateTime=dateTime};
        }


        /// <summary>
        /// Удаление объекта после каждого теста
        /// </summary>
        [TearDown]
        public void DelDTO()
        {
            gameRezult = null;
        }

        /// <summary>
        /// Проверяем, что объект не изменяет данные 
        /// </summary>
        [Test]
        public void GameRezultDTO_Сhecking_Data_Not_Changed()
        {
            //проверка, что количество свойст =3
            Assert.AreEqual(3, typeof(GameRezultDTO).GetProperties().Length);

            Assert.IsTrue(gameRezult.Name == name);
            Assert.IsFalse(gameRezult.Score != score);
            Assert.IsTrue(gameRezult.DateTime == dateTime);
        }

        /// <summary>
        /// Проверка, что объект хранит данные в тех же типах
        /// </summary>
        [Test]
        public void GameRezultDTO_Сhecking_Types_Not_Changed()
        {
            //проверка, что количество свойст =3
            Assert.AreEqual(3, typeof(GameRezultDTO).GetProperties().Length);

            Assert.That(gameRezult.Name, Is.TypeOf(typeof(string)));
            Assert.That(gameRezult.Score, Is.TypeOf(typeof(int)));
            Assert.That(gameRezult.DateTime, Is.TypeOf(typeof(DateTime)));
        }



        /// <summary>
        /// Проверяем, что невозможно установить значение Score меньше нуля
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingMinNumberColumns_GenerateArgumentOutOfRangeException()
        {
            GameRezultDTO gameRezultDTO = new GameRezultDTO();
            Assert.That(() => gameRezultDTO.Score = - 1, Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        //public void GameRezultDTO_CreateDTOwithRandomData_Сhecking_Data_Not_Changed()
        //    {
        //        //Раздел Arrange (Тестируемое значение) 
        //        PropertyInfo[] properties = typeof(GameRezultDTO).GetProperties();

        //        //Раздел Act (Результат теста)
        //        GameRezultDTO gameRezultDTO = new GameRezultDTO();
        //        foreach (var item in properties)
        //        {
        //            GetValues

        //            typeof(GameRezultDTO).GetProperty(item.Name).SetValue(gameRezultDTO, );

        //        }


        //        //Раздел Assert (Проверка утверждения) 
        //    }
    }
}
