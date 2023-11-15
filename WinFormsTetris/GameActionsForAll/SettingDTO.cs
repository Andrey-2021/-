using System;

namespace GameActionsForAll
{
    /// <summary>
    /// Класс, содержащие настройки игрового поля
    /// </summary>
    public class SettingDTO
    {
        /// <summary>
        /// Минимально допустимое количество строк игрового поля
        /// </summary>
        public int MinRows => 8;

        /// <summary>
        /// Максимально допустимое количество строк игрового поля
        /// </summary>
        public int MaxRows => 15;


        /// <summary>
        /// Минимально допустимое количество столбцов игрового поля
        /// </summary>
        public int MinColumns => 6;

        /// <summary>
        /// Максимально допустимое количество столбцов игрового поля
        /// </summary>
        public int MaxColumns => 14;

        /// <summary>
        /// Количество строк
        /// </summary>
        public int numberRows=12;

        /// <summary>
        /// Количество строк
        /// </summary>
        public int NumberRows
        {
            get
            {
                return numberRows;
            }
            set
            {
                if (value < MinRows || value > MaxRows) throw new ArgumentOutOfRangeException();
                else numberRows = value;
            }
        }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        int numberColumns = 8;

        /// <summary>
        /// Количество столбцов
        /// </summary>
        public int NumberColumns
        {
            get
            {
                return numberColumns;
            }
            set
            {
                if (value < MinColumns || value > MaxColumns) throw new ArgumentOutOfRangeException();
                else numberColumns = value;
            }
        }

        /// <summary>
        /// Классический/расширеный набор фигур
        /// </summary>
        public bool IsClassicFigureMode { get; set; }
    }
}
