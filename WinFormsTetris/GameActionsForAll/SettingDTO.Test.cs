using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameActionsForAll
{

    /// <summary>
    /// Тестирование класса SettingDTO
    /// </summary>
    [TestFixture]
    class SettingDTOTest
    {

        int numberRows  = 15;
        int numberColumns = 10;
        bool isClassicFigureMode = true;

        SettingDTO settingDTO;

        /// <summary>
        /// Создание объекта перед запуском каждго теста
        /// </summary>
        [SetUp]
        public void CreateDTO()
        {
            settingDTO = new SettingDTO() { NumberRows= numberRows, NumberColumns= numberColumns, IsClassicFigureMode= isClassicFigureMode};
        }



        /// <summary>
        /// Удаление объекта после каждого теста
        /// </summary>
        [TearDown]
        public void DelDTO()
        {
            settingDTO= null;
        }


        /// <summary>
        /// Проверяем, что объект не изменяет данные 
        /// </summary>
        [Test]
        public void SettngDTO_Сhecking_Data_Not_Changed()
        {
            //проверка, что количество свойст =7
            Assert.AreEqual(7, typeof(SettingDTO).GetProperties().Length);

            Assert.IsTrue(settingDTO.NumberRows== numberRows);
            Assert.IsFalse(settingDTO.NumberColumns != numberColumns);
            Assert.IsTrue(settingDTO.IsClassicFigureMode == isClassicFigureMode);
        }


        /// <summary>
        /// Проверка, что объект хранит данные в тех же типах
        /// </summary>
        [Test]
        public void GameRezultDTO_Сhecking_Types_Not_Changed()
        {
            //проверка, что количество свойст =7
            Assert.AreEqual(7, typeof(SettingDTO).GetProperties().Length);

            Assert.That(settingDTO.NumberRows, Is.TypeOf(typeof(int)));
            Assert.That(settingDTO.NumberColumns, Is.TypeOf(typeof(int)));
            Assert.That(settingDTO.IsClassicFigureMode, Is.TypeOf(typeof(bool)));

            Assert.That(settingDTO.MinRows, Is.TypeOf(typeof(int)));
            Assert.That(settingDTO.MaxRows, Is.TypeOf(typeof(int)));
            Assert.That(settingDTO.MinColumns, Is.TypeOf(typeof(int)));
            Assert.That(settingDTO.MaxColumns, Is.TypeOf(typeof(int)));
        }


        /// <summary>
        /// Проверяем, что невозможно установить значение NumberColumns меньше MinColumns
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingMinNumberColumns_GenerateArgumentOutOfRangeException()
        {
            SettingDTO settingDTO = new SettingDTO();
            Assert.That(() => settingDTO.NumberColumns = settingDTO.MinColumns-1, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Проверяем, что невозможно установить значение NumberColumns больше MaxColumns
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingMaxNumberColumns_GenerateArgumentOutOfRangeException()
        {
            SettingDTO settingDTO = new SettingDTO();
            Assert.That(() => settingDTO.NumberColumns = settingDTO.MaxColumns + 1, Throws.TypeOf<ArgumentOutOfRangeException>());
        }



        /// <summary>
        /// Проверяем, что невозможно установить значение NumberRows меньше MinColumns
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingMinNumberRows_GenerateArgumentOutOfRangeException()
        {
            SettingDTO settingDTO = new SettingDTO();
            Assert.That(() => settingDTO.NumberRows = settingDTO.MinRows - 1, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Проверяем, что невозможно установить значение NumberColumns больше MaxColumns
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingMaxNumberRows_GenerateArgumentOutOfRangeException()
        {
            SettingDTO settingDTO = new SettingDTO();
            Assert.That(() => settingDTO.NumberRows = settingDTO.MaxRows + 1, Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        /// <summary>
        /// Проверка, что при создании экземпляра класса значения NumberColums и NumberRows лежат в допустимом диапазоне
        /// </summary>
        [Test]
        public void GameRezultDTO_СheckingDefaulValues_InAcceptableRange()
        {
            SettingDTO settingDTO = new SettingDTO();
            Assert.Greater(settingDTO.NumberRows, settingDTO.MinRows);
            Assert.Less(settingDTO.NumberRows, settingDTO.MaxRows);
            Assert.Greater(settingDTO.NumberColumns, settingDTO.MinColumns);
            Assert.Less(settingDTO.NumberColumns, settingDTO.MaxColumns);
        }

    }
}
