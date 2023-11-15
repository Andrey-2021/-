using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс модели для Controller, предсталяющей справочную информацию для пользователя
    /// </summary>
    public interface IModelHelpInterfaceForController
    {
        /// <summary>
        /// Получить список параграфов
        /// </summary>
        public void GetParagraphList();

        /// <summary>
        /// Получить текс для параграфа
        /// </summary>
        /// <param name="paragraphName">Название паранрафа, для которого надо получаем текст</param>
        public void GetText(string paragraphName);


        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow();
    }
}
