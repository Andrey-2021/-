using GameActionsForAll;
using System;
using System.Collections.Generic;

namespace ViewConsole
{
    /// <summary>
    /// Класс. Команды
    /// </summary>
   public class ConsoleCommands
    {
        /// <summary>
        /// Создать словарь доступных команд
        /// </summary>
        /// <param name="view">Представление, методы которого будут вызываться для команд окна</param>
        /// <returns>Словарь команд</returns>
        public static Dictionary<ConsoleKey, CommandRecord> CreateCommands(ConsoleController view)
        {
            var s = new Dictionary<ConsoleKey, CommandRecord>()
            {

             { ConsoleKey.F1, new CommandRecord { _isFigureCommand = false, _name = "F1 - Помощь", _gameAction = GameActions.help, _method = view.OnForKeyPressed } },

             { ConsoleKey.F2, new CommandRecord { _isFigureCommand = false, _name = "F2 - Начать игру", _gameAction = GameActions.none, _method = view.OnStartingGame } },
             { ConsoleKey.F3, new CommandRecord { _isFigureCommand = false, _name = "F3 - Остановить игру", _gameAction = GameActions.none, _method = view.OnStoppingGame } },


                { ConsoleKey.F5, new CommandRecord { _isFigureCommand = false, _name = "F5 - Результаты", _gameAction = GameActions.showAllRezults, _method = view.OnForKeyPressed } },
                { ConsoleKey.F6, new CommandRecord { _isFigureCommand = false, _name = "F6 - Настройки", _gameAction = GameActions.settings, _method = view.OnForKeyPressed } },

                { ConsoleKey.F10, new CommandRecord { _isFigureCommand = false, _name = "F10 - Выход", _gameAction = GameActions.none, _method = view.OnClosingGame } },

                { ConsoleKey.LeftArrow, new CommandRecord { _isFigureCommand = true, _name = "< - влево", _gameAction = GameActions.moveLeft, _method = null } },
                { ConsoleKey.RightArrow, new CommandRecord { _isFigureCommand = true, _name = "\u2192 - вправо", _gameAction = GameActions.moveRight, _method = null } },
                { ConsoleKey.DownArrow, new CommandRecord { _isFigureCommand = true, _name = "\u2193 - вниз", _gameAction = GameActions.moveDown, _method = null } },
                { ConsoleKey.Z, new CommandRecord { _isFigureCommand = true, _name = "Z - поворот влево", _gameAction = GameActions.rotateLeft, _method = null } },
                { ConsoleKey.X, new CommandRecord { _isFigureCommand = true, _name = "X - поворов вправо", _gameAction = GameActions.rotateRight, _method = null } },
            };

            return s;
        }
    }
}
