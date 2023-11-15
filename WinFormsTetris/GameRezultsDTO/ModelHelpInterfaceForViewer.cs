using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс модели для View, предсталяющей справочную информацию для пользователя
    /// </summary>
    public interface IModelHelpIntefaceForViewer
    {
        /// <summary>
        /// Событие. Есть новый список параграфов.
        /// </summary>
        event EventHandler<List<string>> NewParagraphsRecived;

        /// <summary>
        /// Событие. Есть новый текст
        /// </summary>
        event EventHandler<string> NewTextRecived;

        /// <summary>
        /// Показать окно
        /// </summary>
        event EventHandler ShowNewWindow;
    }
}
