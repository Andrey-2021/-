using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    /// <summary>
    /// Интерфейс модели для Viewer (со строны Viewer)
    /// </summary>
    public interface IModelInterfaceForViewer
    {
        /// <summary>
        /// Цвет пустой ячейки
        /// </summary>
        ConsoleColor BackgroundBordColor { get; }

        /// <summary>
        /// Набранные очки
        /// </summary>
        int Score { get; }


        /// <summary>
        /// Возвращает доску
        /// </summary>
        /// <returns>Массив, содержащий цвета в ячейках доски</returns>
        ConsoleColor[,] GetBoard { get; }


        /// <summary>
        /// Контекст синхронизации
        /// </summary>
        /// статьи
        /// https://docs.microsoft.com/ru-ru/archive/msdn-magazine/2011/february/msdn-magazine-parallel-computing-it-s-all-about-the-synchronizationcontext
        /// https://ru.stackoverflow.com/questions/559590/c-net-eventhandler-%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D1%8F-%D1%81%D0%BE%D0%B1%D1%8B%D1%82%D0%B8%D1%8F-%D0%B8%D0%B7-%D0%B4%D1%80%D1%83%D0%B3%D0%BE%D0%B3%D0%BE-%D0%BF%D0%BE%D1%82%D0%BE%D0%BA%D0%B0
        /// 
        SynchronizationContext SyncContext { get; set; }




        /// <summary>
        /// Событие. Создана новая доска
        /// </summary>
        event EventHandler<GameBox> CreatedNewBord;


        /// <summary>
        /// Событие. Доска изменена.
        /// </summary>
        event EventHandler BordChanged;

        /// <summary>
        /// Событие. Счёт изменён
        /// </summary>
        event EventHandler ScoreChanged;


        /// <summary>
        /// Событие. Конец Игре.
        /// </summary>
        event EventHandler GameEnded;

        /// <summary>
        /// Событие. Viewer можно закрывать.
        /// </summary>
        event EventHandler CanClosingViewer;

    }
}
