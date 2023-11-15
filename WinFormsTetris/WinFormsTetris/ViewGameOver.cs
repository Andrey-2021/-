using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;
using WinFormsTetris;

namespace WinFormsApp1
{
    /// <summary>
    ///Класс. View для окна окончания игры
    /// </summary>
    public class ViewGameOver : ViewForAll<ViewGameOverWindow>, IViewInterfaceForGameOverController
    {

        public event EventHandler<string> SavingRezult;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewGameOver()
        {
            _window = new ViewGameOverWindow();
            _window.buttonCancel.Click += ButtonCloseClick;
            _window.buttonSave.Click += ButtonSaveClick;
        }


        public void SetModel(IModelRezultsInterface parModel)
        {
            parModel.NewCurrentRezultRecived += RevreshCurrentRezult;
            parModel.ShowNewWindow += ShowWindow;
        }

        /// <summary>
        /// Показываем текущий результат
        /// </summary>
        void RevreshCurrentRezult(object sender, GameRezultDTO parRezultDTO)
        {
            _window.textBoxScore.Text = parRezultDTO.Score.ToString();
            _window.textBoxDate.Text = parRezultDTO.DateTime.ToString();
        }

        /// <summary>
        /// Сохранить результат
        /// </summary>
        void OnSaveRezult()
        {
            SavingRezult?.Invoke(this, _window.textBoxFIO.Text);
            _window.Close();
        }

        /// <summary>
        /// Метод для обработки события. Нажатия книпки "Закрыть окно"
        /// </summary>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            _window.Close();
        }

        /// <summary>
        /// Метод для обработки события. Нажатие кнопки "Сохранить результат"
        /// </summary>
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            OnSaveRezult();
        }
    }
}
