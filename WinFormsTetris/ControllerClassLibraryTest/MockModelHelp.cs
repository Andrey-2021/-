using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerClassLibraryTest
{

    /// <summary>
    /// Mock-класс ModelHelp окна Помощи, для тестирования класса HelpController
    /// </summary>
    public class MockModelHelp : IModelHelpInterface
    {
        public event EventHandler<List<string>> NewParagraphsRecived;
        public event EventHandler<string> NewTextRecived;
        public event EventHandler ShowNewWindow;


        /// <summary>
        /// Флаг, показывает что метод ParagraphList отработал 
        /// </summary>
        public bool isMethodGetParagraphListISWorked = false;


        /// <summary>
        /// Флаг, показывает что метод GetText отработал 
        /// </summary>
        public bool isMethodGetTextISWorked = false;

        /// <summary>
        /// Флаг, показывает что метод ShowWindow отработал 
        /// </summary>
        public bool isMethodShowWindowISWorked = false;


        public void GetParagraphList()
        {
            isMethodGetParagraphListISWorked = true;
        }

        public void GetText(string parParagraphName)
        {
            isMethodGetTextISWorked = true;
        }


        /// <summary>
        /// Показать окно
        /// </summary>
        public void ShowWindow()
        {
            isMethodShowWindowISWorked = true;
        }
    }
}
