using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{

    /// <summary>
    /// Тесты для тестирования класса MaxRezult
    /// </summary>
    [TestFixture]
    public class MaxRezultTest
    {
        /// <summary>
        /// Проверяем, что возвращает метод GetMaxRezult, когда ему в качестве списка результатов передаём Null.
        /// Ожидаем возвращение экземпляра класса GameRezultDTO с пустыми значениями/по умолчанию свойств 
        /// </summary>
        [Test]
        public static void GetMaxRezult_WithNullRezultsList_CleanObjectExpected()
        {
            //Раздел Arrange (Тестируемое значение) 
            List<GameRezultDTO> rezultsDTO = null;

            //Раздел Act (Результат теста)
            GameRezultDTO rezult = MaxRezult.GetMaxRezult(rezultsDTO);

            //Раздел Assert (Проверка утверждения) 
            Assert.AreEqual("", rezult.Name);
            Assert.AreEqual(0, rezult.Score);
            Assert.AreEqual(DateTime.MinValue, rezult.DateTime);
        }

        /// <summary>
        /// Проверяем, что возвращает метод GetMaxRezult, когда ему в качестве списка результатов передаём пустой список.
        /// Ожидаем возвращение экземпляра класса GameRezultDTO с пустыми значениями/по умолчанию свойств 
        /// </summary>
        [Test]
        public static void GetMaxRezult_WithEmptyRezultsList_CleanObjectExpected()
        {
            //Раздел Arrange (Тестируемое значение) 
            List<GameRezultDTO> rezultsDTO = new List<GameRezultDTO>();

            //Раздел Act (Результат теста)
            GameRezultDTO rezult = MaxRezult.GetMaxRezult(rezultsDTO);

            //Раздел Assert (Проверка утверждения) 
            Assert.IsEmpty(rezult.Name);
            Assert.IsTrue(rezult.Name=="");
            Assert.IsTrue(rezult.Score==0);
            Assert.IsTrue(rezult.DateTime== DateTime.MinValue);
        }


        /// <summary>
        /// Проверяем, что возвращает метод GetMaxRezult, когда в списке результатов только один объект GameRezultDTO.
        /// </summary>
        [Test]
        public static void GetMaxRezult_WithOneElementInRezultsList_ThisElementAsMaxRezultExpected()
        {
            //Раздел Arrange (Тестируемое значение) 
            GameRezultDTO gameRezult = new GameRezultDTO() { Name = "Пётр", Score = 123, DateTime = new DateTime(2021, 12, 15) };
            List<GameRezultDTO> list = new List<GameRezultDTO>();
            list.Add(gameRezult);

            //Раздел Act (Результат теста)
            //Раздел Assert (Проверка утверждения) 
            Assert.AreSame(gameRezult, MaxRezult.GetMaxRezult(list));
        }

        /// <summary>
        /// Проверяем, что возвращает метод GetMaxRezult, когда в списке результатов несколько объект GameRezultDTO.
        /// </summary>
        [Test]
        public static void GetMaxRezult_WithSeveralElementsInRezultsList_MaxRezultExpected()
        {
            //Раздел Arrange (Тестируемое значение) 
            GameRezultDTO minGameRezult = new GameRezultDTO() { Name = "Пётр", Score = 21, DateTime = new DateTime(2021, 12, 15) };
            GameRezultDTO avgGameRezult = new GameRezultDTO() { Name = "Ben", Score = 100, DateTime = new DateTime(2020, 08, 11) };
            GameRezultDTO maxGameRezult = new GameRezultDTO() { Name = "Вася", Score = 263, DateTime = new DateTime(2019, 11, 07) };

            List<GameRezultDTO> list = new List<GameRezultDTO>();
            list.Add(minGameRezult);
            list.Add(avgGameRezult);
            list.Add(maxGameRezult);

            //Раздел Act (Результат теста)
            //Раздел Assert (Проверка утверждения) 
            Assert.AreSame(maxGameRezult, MaxRezult.GetMaxRezult(list));
        }



        /// <summary>
        /// Проверка типа возвращаемого объекта
        /// </summary>
        [Test]
        public static void GetMaxRezult_ShouldReturnInstanc_GameRezultDTO_Type()
        {
            Assert.IsInstanceOf(typeof(GameRezultDTO), MaxRezult.GetMaxRezult(null));
        }
    }
}
