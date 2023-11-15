using ControllerClassLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace ControllerClassLibraryTest
{

    /// <summary>
    /// Тестиролвание класса HelpController
    /// </summary>
    [TestFixture]
    class HelpControllerTest
    {

        /// <summary>
        /// Проверяем, что вызов события  GettingParagraphList в ViewHelp приведёт к вызову подписчиков в классе HelpController
        /// (метод GetParagraphList),
        /// а это приведёт к вызову метода GetParagraphList в ModelHelp
        /// </summary>

        [Test]
        public static void HelpController_CheckGetParagraphListMethod_CallGetParagraphListMethodInModelExpected()
        {
            MockViewHelp helpView = new MockViewHelp();
            MockModelHelp helpModel = new MockModelHelp();
            HelpController helpController = new HelpController(helpView, helpModel);

            Assert.AreEqual(false, helpModel.isMethodGetParagraphListISWorked); //проверили значение до вызова метода
            helpView.OnRecivingParagraphList();
            Assert.AreEqual(true, helpModel.isMethodGetParagraphListISWorked); //проверили значение после вызова метода
        }

        /// <summary>
        /// Проверяем, что вызов события  GettingText в ViewHelp приведёт к вызову подписчиков в классе HelpController 
        /// (метод GetText) ,
        /// а это приведёт к вызову метода GetText в ModelHelp
        /// </summary>
        [Test]
        public static void HelpController_CheckGetTextMethod_CallGetTextMethodInModelExpected()
        {
            MockViewHelp helpView = new MockViewHelp();
            MockModelHelp helpModel = new MockModelHelp();
            HelpController helpController = new HelpController(helpView, helpModel);

            Assert.AreEqual(false, helpModel.isMethodGetTextISWorked); //проверили значение до вызова метода
            helpView.OnRecivingText(null);
            Assert.AreEqual(true, helpModel.isMethodGetTextISWorked); //проверили значение после вызова метода
        }


        /// <summary>
        /// Проверяем, что метод Start() класса HelpController вызовает метод ShowWindow класса модели, реализующей интерфейс IModelHelpInterface
        /// </summary>
        [Test]
        public static void HelpController_CheckStartMethod_CallShowWindowMethodInModelExpected()
        {
            IViewInterfaceForHelp helpView = new MockViewHelp();
            MockModelHelp helpModel = new MockModelHelp();

            HelpController helpController = new HelpController(helpView, helpModel);
            Assert.AreEqual(false, helpModel.isMethodShowWindowISWorked); //проверили значение до вызова метода
            helpController.Start();
            Assert.AreEqual(true, helpModel.isMethodShowWindowISWorked); //проверили значение после вызова метода
        }



    }
}
