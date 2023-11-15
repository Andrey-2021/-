using ModelHelper;
using System;

namespace ViewInterfaces
{
    /// <summary>
    /// Интерфейс. Интерфейс View для Controller, отвечающего за работу с окном и данными окончания игры
    /// </summary>
    public interface IViewInterfaceForGameOverController: IShowCommonInterface
    {

        /// <summary>
        /// Событие. Сохранить результат
        /// </summary>
        event EventHandler<string> SavingRezult;


        /// <summary>
        /// В методе подписываемся на события Model (модели)
        /// </summary>
        /// <param name="parModel">Model</param>
        void SetModel(IModelRezultsInterface parModel);
    }
}
