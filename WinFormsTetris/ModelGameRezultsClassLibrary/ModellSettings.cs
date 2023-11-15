using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsClassLibrary
{
    /// <summary>
    /// Класс model для настроек
    /// </summary>
    public class ModellSettings: ISettingsModel
    {
        /// <summary>
        /// Настройки
        /// </summary>
        SettingDTO _settingDTO { get; set; }

        public event EventHandler<SettingDTO> SettingsChanged;
        public event EventHandler SettingsApplied;
        public event EventHandler ShowNewWindow;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ModellSettings(SettingDTO settingDTO)
        {
            OnSettingChanging(settingDTO);
        }


        /// <summary>
        /// Метод оповещает подписчиков, что настройки применены
        /// </summary>
        void OnSettingsApplied()
        {
            SettingsApplied?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод оповещает подписчиков, что настройки изменены
        /// </summary>
        void OnSettingChanging(SettingDTO settingDTO)
        {
            this._settingDTO = settingDTO;
            SettingsChanged?.Invoke(this, this._settingDTO);
            OnSettingsApplied();
        }



        public SettingDTO GetSetting()
        {
            return _settingDTO;
        }

        public void SettingDTO(SettingDTO parSettingDTO)
        {
            //Console.Beep();
            OnSettingChanging(parSettingDTO);
        }

        /// <summary>
        /// Показать окно
        /// </summary>
        public void ShowWindow()
        {
            ShowNewWindow?.Invoke(this, EventArgs.Empty);
        }

    }

   
}
