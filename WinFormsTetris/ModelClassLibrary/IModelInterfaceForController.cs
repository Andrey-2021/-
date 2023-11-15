using GameActionsForAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    /// <summary>
    /// Интерфейс модели для контроллера (со строны контоллера)
    /// </summary>
   public interface IModelInterfaceForController
    {
        /// <summary>
        /// Игровое поле
        /// </summary>
        GameBox GameBox { get; set; }


        /// <summary>
        /// Старт новой игры
        /// </summary>
        void StartGame();


        /// <summary>
        /// Остановка игры
        /// </summary>
        void StopGame();


        /// <summary>
        /// Закрытие игры
        /// </summary>
        void CloseGame();


        /// <summary>
        /// Действие над текущей фигурой
        /// </summary>
        /// <param name="actions"></param>
        void ActionOnFigure(GameActions actions);

    }
}
