using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Нахождение максимального результата
    /// </summary>
    public class MaxRezult
    {
        /// <summary>
        /// Метод находит первую запись с максимальным количеством очков
        /// </summary>
        /// <param name="parRezultsDTO">Список результатов</param>
        /// <returns>Первая запись с максимальным количеством осков</returns>
        public static GameRezultDTO GetMaxRezult(List<GameRezultDTO> parRezultsDTO)
        {
            if (parRezultsDTO==null || parRezultsDTO.Count == 0) //если результатов игр нет
            {
                return new GameRezultDTO() { Name = "", Score = 0, DateTime = DateTime.MinValue };
            }

            var max = parRezultsDTO.Max(z => z.Score); //максимальное значение очков
            var maxRecord = parRezultsDTO.First(z => z.Score == max); //находим только ПЕРВУЮ запись с таким количеством очков
            return maxRecord;
        }
    }
}
