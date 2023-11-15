using GameActionsForAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс модели, осуществляющей настройки
    /// </summary>
    public interface ISettingsModel
    {
        /// <summary>
        /// Событие. Настройки изменились
        /// </summary>
        event EventHandler<SettingDTO> SettingsChanged;

        /// <summary>
        /// Получить настройки
        /// </summary>
        /// <returns></returns>
        public SettingDTO GetSetting();

        /// <summary>
        /// Установить настройки
        /// </summary>
        /// <param name="settingDTO"></param>
        public void SettingDTO(SettingDTO settingDTO);


        /// <summary>
        /// Событие. Настройки удачно применены
        /// </summary>
        event EventHandler SettingsApplied;

        /// <summary>
        /// Показать окно
        /// </summary>
        event EventHandler ShowNewWindow;

        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow();
    }
}
