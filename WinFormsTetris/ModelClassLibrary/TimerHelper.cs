using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModelClassLibrary
{
    /// <summary>
    /// Вспомогательный класс для настройки таймера
    /// </summary>
    class TimerHelper
    {
        /// <summary>
        /// Интервал тамера для выполнения движения фигуры вниз
        /// </summary>
        public const int TICK_TIME_DOWN_MOVE = 500;

        /// <summary>
        /// Интервал тамера, через который обрабатывается команда пользователя
        /// </summary>
        public const int TICK_TIME_USER_COMMAND = 100;

        public static System.Timers.Timer GetNewTimer(double parInterval, ElapsedEventHandler parMethod)
        {
            // Create a timer with interval.
            System.Timers.Timer timer = new System.Timers.Timer(parInterval);

            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += parMethod;
            timer.AutoReset = true;
            timer.Enabled = false;

            // Если SynchronizingObject свойство имеет значение null , Elapsed событие вызывается в ThreadPool потоке.
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.timers.timer.elapsed?view=netframework-4.8
            //timer.SynchronizingObject = this;

            return timer;
        }
    }
}
