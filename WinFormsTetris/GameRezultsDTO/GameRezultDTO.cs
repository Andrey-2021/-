using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelHelper
{
    /// <summary>
    /// Класс используемый для передачи результатов игр
    /// </summary>
    public class GameRezultDTO //Date Transfer Object 
    {
        /// <summary>
        /// ФИО игрока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Очки игрока
        /// </summary>
        int score;

        /// <summary>
        /// Очки игрока
        /// </summary>
        public int Score 
        {
            get
            {
                return score;
            }

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                else score = value;
            }
        }

        /// <summary>
        /// Дата игры
        /// </summary>
        public DateTime DateTime { get; set; }
    }

}
