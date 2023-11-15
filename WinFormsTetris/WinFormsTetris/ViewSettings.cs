using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ViewInterfaces;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс. Представляет View для окна настроек игры
    /// </summary>
    public class ViewSettings : ViewForAll<ViewSettingsWindow>, IViewInterfaceForSettings
    {
        public event EventHandler<SettingDTO> NewSettingInstalledInView;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewSettings()
        {
            _window = new ViewSettingsWindow();
            _window.buttonCancel.Click += ButtonCancelClick;
            _window.trackBarRows.Scroll += TrackBarRowsScroll;
            _window.trackBarColumns.Scroll += TrackBarColumnsScroll;
            _window.buttonSave.Click += ButtonSaveClick;
        }


        public void SetModel(ISettingsModel parModel)
        {
            parModel.SettingsChanged += RefreshView;
            parModel.SettingsApplied += ShowInfo;
            parModel.ShowNewWindow += ShowWindow;

            SetControlsOnForm(parModel.GetSetting());
        }


        /// <summary>
        /// Вывод информации о том, что настройки применены
        /// </summary>
        void ShowInfo(Object obj, EventArgs args)
        {
            MessageBox.Show("Настройки применены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обновить View
        /// </summary>
        void RefreshView(object obj, SettingDTO parSettingDTO)
        {
            SetControlsOnForm(parSettingDTO);
        }


        /// <summary>
        /// Оповестить подписчиков об установке новых настроек
        /// </summary>
        void OnNewSettingInstalledInView(SettingDTO parSettingDTO)
        {
            NewSettingInstalledInView?.Invoke(this, parSettingDTO);
        }

        /// <summary>
        /// Установка новых настроек пользователя
        /// </summary>
        void SetNewSetting()
        {
            SettingDTO settingDTO = new SettingDTO();

            settingDTO.NumberRows = _window.trackBarRows.Value;
            settingDTO.NumberColumns = _window.trackBarColumns.Value;
            if (_window.radioButtonStandartSet.Checked) settingDTO.IsClassicFigureMode = true;
            else settingDTO.IsClassicFigureMode = false;

            OnNewSettingInstalledInView(settingDTO); //проинформировать подписчиков, что надо установить новые настройки
        }

        /// <summary>
        /// Настройка вида элементов на форме
        /// </summary>
        /// <param name="parSettingDTO">Текущие настройки</param>
        void SetControlsOnForm(SettingDTO parSettingDTO)
        {
            _window.trackBarRows.Minimum = parSettingDTO.MinRows;
            _window.trackBarRows.Maximum = parSettingDTO.MaxRows;
            _window.trackBarRows.Value = parSettingDTO.NumberRows;

            _window.trackBarColumns.Minimum = parSettingDTO.MinColumns;
            _window.trackBarColumns.Maximum = parSettingDTO.MaxColumns;
            _window.trackBarColumns.Value = parSettingDTO.NumberColumns;

            if (parSettingDTO.IsClassicFigureMode) _window.radioButtonStandartSet.Checked = true;
            else _window.radioButtonExtendedSet.Checked = true;

            ChangeRowText();
            ChangeColumnText();
        }


        /// <summary>
        /// Изменить текст надписи о количестве строк
        /// </summary>
        void ChangeRowText()
        {
            _window.labelRows.Text = "Текущее значение: " + _window.trackBarRows.Value;
        }


        /// <summary>
        /// Изменяет текст надписи о количестве столбцов
        /// </summary>
        void ChangeColumnText()
        {
            _window.labelColumns.Text = "Текущее значение: " + _window.trackBarColumns.Value;
        }

        /// <summary>
        /// Метод, обрабатывает событие нажатие изменение значения ползунка TrackBar, отвечающего за количество строк игрового поля
        /// </summary>
        private void TrackBarRowsScroll(object sender, EventArgs e)
        {
            ChangeRowText();
        }

        /// <summary>
        /// Метод, обрабатывает событие нажатие изменение значения ползунка TrackBar, отвечающего за количество столбцов игрового поля
        /// </summary>
        private void TrackBarColumnsScroll(object sender, EventArgs e)
        {
            ChangeColumnText();
        }


        /// <summary>
        /// Метод, обрабатывает событие нажатие кнопки Сохранить
        /// </summary>
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            SetNewSetting();
        }

        /// <summary>
        /// Метод, обрабатывает событие нажатие кнопки Закрыть
        /// </summary>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            _window.Close();
        }

       
    }
}

