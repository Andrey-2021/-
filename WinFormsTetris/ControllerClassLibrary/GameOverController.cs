
using ModelClassLibrary;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using ViewInterfaces;

namespace ControllerClassLibrary
{

    /// <summary>
    /// Controller, отвечающий за вывод информации после окончания игры
    /// </summary>
    class GameOverController: ICommonInterface
    {
        /// <summary>
        /// View для текущего контроллера
        /// </summary>
        IViewInterfaceForGameOverController _view;

        /// <summary>
        /// Model для текущего контроллера
        /// </summary>
        IModelRezultsInterface _model;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parView">View с которым работает контроллер</param>
        /// <param name="parModel">Model с которой работает контроллер</param>
        /// /// <param name="parScore">Результат игры</param>
        public GameOverController(IViewInterfaceForGameOverController parView, IModelRezultsInterface parModel, int parScore)
        {
            this._view = parView;
            this._model = parModel;
            this._view.SetModel(parModel);

            this._view.SavingRezult += SaveFIO;
            this._model.SetCurrentRezult(parScore, DateTime.Now);
        }

        /// <summary>
        /// Метод, начинающий работы с View и Model результатов игры
        /// </summary>
        public void Start()
        {
            _model.ShowWindow();
        }

        /// <summary>
        /// Запись данных в модель
        /// </summary>
        void SaveFIO(object parObject, string parFio)
        {
            _model.SaveCurrentRezultToDb(parFio);
        }

    }
}
