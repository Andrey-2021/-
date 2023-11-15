using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{

    /// <summary>
    /// Интерфейс хранилища данных (Model), в котором хранятся результаты игр
    /// </summary>
    public interface IModelRezultsInterface: IModelRezultsForView, IModelRezultsForController
    {
    }
}
