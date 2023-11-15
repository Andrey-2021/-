using GameActionsForAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewConsole
{
    /// <summary>
    /// Структура, используемая для хранения информации в словаре команд
    /// </summary>
    public struct CommandRecord
    {
        /// <summary>
        /// Флаг информирующий, что это команда для фигуры. true-это команда для фигуры, false-команда окна 
        /// </summary>
        public bool _isFigureCommand;

        /// <summary>
        /// Надпись
        /// </summary>
        public string _name;

        /// <summary>
        /// Метод, выполняемый для команды окна
        /// </summary>
        public GameActions _gameAction;

        /// <summary>
        /// Команда, выполняемая над фигурой
        /// </summary>
        public Action _method;
    }
}
