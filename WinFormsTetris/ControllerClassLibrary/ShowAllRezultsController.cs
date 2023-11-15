using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ViewInterfaces;

namespace ControllerClassLibrary
{
    /// <summary>
    /// Controller, отвечающий за просмотр результатов игр
    /// </summary>
    class ShowAllRezultsController
    {
        IViewInterfaceForShowAllRezultsController _view;
        IModelRezultsInterface _model;

        public ShowAllRezultsController(IViewInterfaceForShowAllRezultsController parView, IModelRezultsInterface parModel)
        {
            this._view = parView;
            this._model = parModel;
            this._view.SetModel(parModel);

            this._view.SavingRezult += SaveRezultsReport;
            this._model.ReadRezultsFromDb();
        }

        /// <summary>
        /// Вывод Viewer на экран
        /// </summary>
        public void Start()
        {
            _model?.ShowWindow();
        }


        /// <summary>
        /// Создать и сохранить отчёты по результатам игр
        /// </summary>
        void SaveRezultsReport(object folder, List<FileFormat> list)
        {
            _model.SaveRezultsReports(list, folder as string);
        }
    }
}
