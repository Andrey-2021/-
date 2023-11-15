using GameActionsForAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс хранилища данных (Model) для Controller, в котором хранятся результаты игр
    /// </summary>
    public interface IModelRezultsForController
    {
        /// <summary>
        /// Запись результатов игры в хранилище данных
        /// </summary>
        /// <param name="gameRezult"></param>
        void SaveCurrentRezultToDb(string fio);

        /// <summary>
        /// Установка текущего результата
        /// </summary>
        /// <param name="score">Результат игры</param>
        /// <param name="date">Дата игры</param>
        void SetCurrentRezult(int score, DateTime date);

        /// <summary>
        /// Получить все результаты игр из хранилища данных
        /// </summary>
        /// <returns></returns>
        void ReadRezultsFromDb();

        /// <summary>
        /// Сохранить результаты игр в файлах-отчётах
        /// </summary>
        /// <param name="filesFotmats"></param>
        void SaveRezultsReports(List<FileFormat> filesFotmats, string folder);


        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow();
    }
}
