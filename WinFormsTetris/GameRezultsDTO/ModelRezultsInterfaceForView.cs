using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс хранилища данных (Model) для View, в котором хранятся результаты игр
    /// </summary>
    public interface IModelRezultsForView
    {
        /// <summary>
        /// Событие. Есть текущие результаты
        /// </summary>
        event EventHandler<GameRezultDTO> NewCurrentRezultRecived;

        /// <summary>
        /// Событие. Есть новый список результатов.
        /// </summary>
        event EventHandler<List<GameRezultDTO>> NewListRezultsRecived;

        /// <summary>
        /// Событие. Отчёты о результатах игр сохранены.
        /// </summary>
        event EventHandler ReportsSaved;

        /// <summary>
        /// Событие. Отчёты о результатах игр не сохранены.
        /// </summary>
        event EventHandler<string> ReportsNotSaved;


        /// <summary>
        /// Событие. Показать окно
        /// </summary>
        event EventHandler ShowNewWindow;
    }
}
