using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewInterfaces
{

    /// <summary>
    /// Интерфейс. Интерфейс View для Controller, отвечающего за работу с окном и данными Настроек
    /// </summary>

    public interface IViewInterfaceForSettings: IShowCommonInterface
    {

        /// <summary>
        /// Событие. В View установлены новые настройки
        /// </summary>
        event EventHandler<SettingDTO> NewSettingInstalledInView;


        /// <summary>
        /// Подписываемся на события модели для View
        /// </summary>
        void SetModel(ISettingsModel parModel);
    }
}
