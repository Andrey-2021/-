using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace ControllerClassLibraryTest
{

    /// <summary>
    /// Mock-Класс IViewInterfaceForHelp. Представляет окно Помощи
    /// </summary>
    public class MockViewHelp : IViewInterfaceForHelp
    {
        public event EventHandler GettingParagraphList;
        public event EventHandler<string> GettingText;

        public void ShowView()
        {
        }

        public void SetModel(IModelHelpIntefaceForViewer parModel)
        {
        }


        /// <summary>
        ///  Метод события. Используемый для создания события запроса списка параграфов
        /// </summary>
        public void OnRecivingParagraphList()
        {
            GettingParagraphList?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события запроса текста выбранного параграфа
        /// </summary>
        public void OnRecivingText(string parParagraphName)
        {
            GettingText?.Invoke(this, parParagraphName);
        }
    }
}
