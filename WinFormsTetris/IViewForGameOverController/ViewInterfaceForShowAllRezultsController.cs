using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewInterfaces
{
    /// <summary>
    /// Интерфейс. Интерфейс View для Controller, отвечающего за работу с окном и данными Результатов игры
    /// </summary>
    public interface IViewInterfaceForShowAllRezultsController: IShowCommonInterface
    {
        /// <summary>
        /// Событие. Сохранить результат
        /// </summary>
        event EventHandler<List<FileFormat>> SavingRezult;

        /// <summary>
        /// Подписываемся на события модели для View
        /// </summary>
        void SetModel(IModelRezultsInterface parModel);

    }
}
