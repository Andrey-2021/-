using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс. Представляет View для окна помощи
    /// </summary>
    public class ViewHelp : ViewForAll<ViewHelpWindows>, IViewInterfaceForHelp
    {
        public event EventHandler GettingParagraphList;
        public event EventHandler<string> GettingText;
        public event EventHandler CloseWindow;


        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewHelp()
        {
            _window = new ViewHelpWindows();
            _window.buttonClose.Click += ButtonCloseClick;
            _window.listBoxParagraphList.SelectedIndexChanged += ListBoxParagraphListSelectedIndexChanged;
        }




        public override void ShowView()
        {
            GettingParagraphList?.Invoke(this, EventArgs.Empty);
            if (_window.listBoxParagraphList.Items.Count > 0) _window.listBoxParagraphList.SelectedIndex = 0;
            _window.ShowDialog();
        }

        public void SetModel(IModelHelpIntefaceForViewer parModel)
        {
            parModel.NewParagraphsRecived += RevreshParagraphList;
            parModel.NewTextRecived += RevreshText;
            parModel.ShowNewWindow += ShowWindow;
        }



        /// <summary>
        /// Обновляем список параграфов
        /// </summary>
        void RevreshParagraphList(object sender, List<string> parParagraphsNames)
        {
            _window.listBoxParagraphList.Items.Clear();
            foreach (var item in parParagraphsNames)
            {
                _window.listBoxParagraphList.Items.Add(item);
            }
        }


        /// <summary>
        /// Обновляем текст/описание
        /// </summary>
        void RevreshText(object sender, string parText)
        {
            _window.textBoxText.Text = parText;
        }


        /// <summary>
        ///  Метод события. Используемый для создания события запроса списка параграфов
        /// </summary>
        void OnRecivingParagraphList()
        {
            GettingParagraphList?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события запроса текста выбранного параграфа
        /// </summary>
        void OnRecivingText(string parParagraphName)
        {
            GettingText?.Invoke(this, parParagraphName);
        }

        /// <summary>
        /// Метод, обрабатывает событие "выбрано новое поле в ListBox"
        /// </summary>
        private void ListBoxParagraphListSelectedIndexChanged(object sender, EventArgs e)
        {
            OnRecivingText(_window.listBoxParagraphList.SelectedItem.ToString());
        }

        /// <summary>
        /// Метод, обрабатывает событие "Нажатие кнопки Закрыть окно"
        /// </summary>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            _window.Close();
            CloseWindow?.Invoke(this, EventArgs.Empty);
        }
    }

}
