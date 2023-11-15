using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerClassLibrary
{
    /// <summary>
    /// Интерфейс для порождаемых контроллеров (от главного)
    /// </summary>
    interface ICommonInterface
    {
        /// <summary>
        /// Метод, служащиё для передачи управления контроллеру
        /// </summary>
        public void Start();
    }
}
