//using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelHelper
{
    /// <summary>
    /// Интерфейс модели, предсталяющей справочную информацию для пользователя
    /// </summary>
    public interface IModelHelpInterface: IModelHelpIntefaceForViewer, IModelHelpInterfaceForController
    {
    }
}
