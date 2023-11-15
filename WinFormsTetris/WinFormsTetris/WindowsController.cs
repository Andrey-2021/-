using ControllerClassLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ViewInterfaces;
using WinFormsApp1;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс. Контроллер для WinowsForm приложения
    /// </summary>
    public class WindowsController
    {
        /// <summary>
        /// Model для главного View и Controller
        /// </summary>
        Model _model;

        /// <summary>
        /// View главного окна
        /// </summary>
        ViewMain _view;

        /// <summary>
        /// Controller главного окна
        /// </summary>
        Controller _controller;

        /// <summary>
        /// Конструктор
        /// </summary>
        public WindowsController()
        {
            _model = new Model();
            _view = new ViewMain(_model);
            _controller = new Controller(_view, _model, GetViewers);
        }

        /// <summary>
        /// Начать работу класса
        /// </summary>
        public void Go()
        {
            _view.Go();
        }

        /// <summary>
        /// Метод создаёт и возвращает View запрошенного типа
        /// </summary>
        /// <param name="parType">Тип View</param>
        public object GetViewers(Type parType)
        {
            if (parType == typeof(IViewInterfaceForController))
            {
                return new ViewMain(_model);
            }


            if (parType == typeof(IViewInterfaceForGameOverController))
            {
                return new ViewGameOver();
            }


            if (parType == typeof(IViewInterfaceForShowAllRezultsController))
            {
                return new ViewShowAllRezults();
            }


            if (parType == typeof(IViewInterfaceForHelp))
            {
                return new ViewHelp();
            }

            if (parType == typeof(IViewInterfaceForSettings))
            {
                return new ViewSettings();
            }


            throw new NotSupportedException();
        }

    }
}
