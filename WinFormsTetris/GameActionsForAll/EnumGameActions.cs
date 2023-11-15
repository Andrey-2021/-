using System;

namespace GameActionsForAll
{
    /// <summary>
    /// Список команд, используемых в программе 
    /// </summary>
    public enum GameActions
    {
        /// <summary>
        /// Движение фигуры в левую сторону
        /// </summary>
        moveLeft,
        /// <summary>
        /// Движение фигуры в правую сторону
        /// </summary>
        moveRight,
        /// <summary>
        /// Движение фигуры вниз
        /// </summary>
        moveDown,
        /// <summary>
        /// Бросить фигуру
        /// </summary>
        dropDown,
        /// <summary>
        /// Поворот фигуры по часовой стрелке
        /// </summary>
        rotateLeft,
        /// <summary>
        /// Поворот фигуры против часовой стрелке
        /// </summary>
        rotateRight,
        /// <summary>
        /// Ничего не делать
        /// </summary>
        none,
        /// <summary>
        /// Игра закончена
        /// </summary>
        GameOver,
        /// <summary>
        /// Показать результаты
        /// </summary>
        showAllRezults,
        /// <summary>
        /// Вывести помощь
        /// </summary>
        help,
        /// <summary>
        /// Вывести настройки
        /// </summary>
        settings
    }
}
