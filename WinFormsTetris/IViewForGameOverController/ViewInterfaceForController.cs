//using SharedProject1;
//using ModelClassLibrary;
using GameActionsForAll;
using System;

namespace ViewInterfaces
{
    /// <summary>
    /// Интерфейс для начальных Консольного и Windows Controller-ов
    /// </summary>
    public interface IViewInterfaceForController
    {

        /// <summary>
        /// Событие. Начало игры
        /// </summary>
        event EventHandler StartingGame;
        
        /// <summary>
        /// Событие. Остановка игры.
        /// </summary>
        event EventHandler StoppingGame;


        /// <summary>
        /// Событие. Остановка игры.
        /// </summary>
        event EventHandler ClosingGame;


        /// <summary>
        /// Событие. Нажатие клавиши
        /// </summary>
        //event EventHandler KeyPressed;
        event EventHandler<GameActions> KeyPressed;
    }
}
