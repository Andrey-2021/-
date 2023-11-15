using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace ControllerClassLibrary
{
    /// <summary>
    /// Controller, отвечающий за настройки в игре
    /// </summary>
    class SettingsController : ICommonInterface
    {
        IViewInterfaceForSettings _view;
        ISettingsModel _model;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parView">View</param>
        /// <param name="parModel">Model</param>
        public SettingsController(IViewInterfaceForSettings parView, ISettingsModel parModel)
        {
            this._view = parView;
            this._model = parModel;
            this._view.SetModel(parModel);

            parView.NewSettingInstalledInView += SetNewSetting;
        }

        /// <summary>
        /// Вывод Viewer на экран
        /// </summary>
        public void Start()
        {
            _model.ShowWindow();
        }

        /// <summary>
        /// Установить новые настройки в Model
        /// </summary>
        /// <param name="parSettingDTO">Новые настройки</param>
        void SetNewSetting(Object parObject, SettingDTO parSettingDTO)
        {
            _model.SettingDTO(parSettingDTO);
        }

        
    }
}
