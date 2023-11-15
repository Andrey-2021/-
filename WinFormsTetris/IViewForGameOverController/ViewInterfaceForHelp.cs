using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewInterfaces
{
    /// <summary>
    /// Интерфейс. Интерфейс View для Controller, отвечающего за работу с окном и данными содержащем информацию о Помощи
    /// </summary>

    public interface IViewInterfaceForHelp:IShowCommonInterface
    {
        /// <summary>
        /// Событие. Получить список параграфов.
        /// </summary>
        event EventHandler GettingParagraphList;


        /// <summary>
        /// Событие. Получить текст для параграфа
        /// </summary>
        //event EventHandler KeyPressed;
        event EventHandler<string> GettingText;

        /// <summary>
        /// Подписываемся на события модели для View
        /// </summary>
        void SetModel(IModelHelpIntefaceForViewer parModel);



        /// <summary>
        /// Событие. Выход
        /// </summary>
        //event EventHandler CloseWindow;

    }
}
