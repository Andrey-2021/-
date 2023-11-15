using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace ControllerClassLibrary
{
    /// <summary>
    /// Controller, отвечающий за вывод справочной информации
    /// </summary>
   public class HelpController : ICommonInterface
    {
        /// <summary>
        /// View-класс для контроллера
        /// </summary>
        IViewInterfaceForHelp _view;
        
        /// <summary>
        /// Mode-класс для конроллера
        /// </summary>
        IModelHelpInterface _model;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parView">View с которым работает контроллер</param>
        /// <param name="parModel">Model с которой работает контроллер</param>
        public HelpController(IViewInterfaceForHelp parView, IModelHelpInterface parModel)
        {
            this._view = parView;
            this._model = parModel;
            this._view.SetModel(parModel);

            this._view.GettingParagraphList += GetParagraphList;
            this._view.GettingText += GetText;
        }

        /// <summary>
        /// Вывод Viewer на экран
        /// </summary>
        public void Start()
        {
            _model.ShowWindow();
        }

        /// <summary>
        /// Запрос у модели списка параграфов 
        /// </summary>
        void GetParagraphList(object parObject, EventArgs parArgs)
        {
            _model.GetParagraphList();
        }

        /// <summary>
        /// Запрос у модели содержимого параграфа
        /// </summary>
        void GetText(object parObject, string parParagraphName)
        {
            _model.GetText(parParagraphName);
        }
    }
}
