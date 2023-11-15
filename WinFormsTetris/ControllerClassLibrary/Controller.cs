using GameActionsForAll;
using ModelClassLibrary;
using ModelGameRezultsClassLibrary;
using ModelHelper;
using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;
using ViewInterfaces;


namespace ControllerClassLibrary
{
    /// <summary>
    /// Главный контроллер и для Windows и для Консоль приложения
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// View для контроллера
        /// </summary>
        readonly IViewInterfaceForController _appController;

        /// <summary>
        /// Model для контроллера
        /// </summary>
        readonly IModelInterfaceForController _model;

        /// <summary>
        /// Список viewers
        /// </summary>
        //List<Object> views;


        /// <summary>
        /// Ссылка на функцию, возвращающую Viewers
        /// </summary>
        Func<Type, object> dGetViews;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parAppController">View</param>
        /// <param name="parModel">Model</param>
        /// <param name="views">Список Viewers</param>

        public Controller(IViewInterfaceForController parAppController, IModelInterfaceForController parModel, Func<Type, object> parFunc)
        {
            this._appController = parAppController;
            this._appController.StartingGame += StartGame;
            this._appController.StoppingGame += StopGame;
            this._appController.KeyPressed += HandlingKeysClick;

            this._model = parModel;
           // this.views = views;
            dGetViews = parFunc;
        }


        



        /// <summary>
        /// Начало игры
        /// </summary>
        void StartGame(object sender, EventArgs ea)
        {
            _model.StartGame();
        }

        /// <summary>
        /// Остановка игры
        /// </summary>
        void StopGame(object sender, EventArgs ea)
        {
            _model.StopGame();
        }

        /// <summary>
        /// Закрыть игру
        /// </summary>
        void CloseGame(object sender, EventArgs ea)
        {
            _model.CloseGame();
        }


        /// <summary>
        /// Обработка нажатой клавиши
        /// </summary>
        void HandlingKeysClick(object parSender, GameActions parAction)
        {
            if (parAction == GameActions.GameOver)
            {
                IViewInterfaceForGameOverController viewGemeOver = dGetViews(typeof(IViewInterfaceForGameOverController)) 
                    as IViewInterfaceForGameOverController;

                
                IModelRezultsInterface dateModel = new ModelGameRezults();
                new GameOverController(viewGemeOver, dateModel, ((IModelInterfaceForViewer)_model).Score).Start();
                return;
            }

            if (parAction==GameActions.showAllRezults)
            {
                IViewInterfaceForShowAllRezultsController viewAllRezults =
                    dGetViews(typeof(IViewInterfaceForShowAllRezultsController))
                    as IViewInterfaceForShowAllRezultsController;

                IModelRezultsInterface rezultsModel = new ModelGameRezults();

                new ShowAllRezultsController(viewAllRezults, rezultsModel).Start();
                return;
            }


            if (parAction == GameActions.settings)
            {
                IViewInterfaceForSettings viewAllRezults =
                    dGetViews(typeof(IViewInterfaceForSettings)) as IViewInterfaceForSettings;

                ISettingsModel settingModel = new ModellSettings(_model.GameBox.SettingDTO);
                settingModel.SettingsChanged += SettingChanged; //todo сюда - надо подписаться на изменение

                new SettingsController(viewAllRezults, settingModel).Start();
                return;
            }

            if (parAction == GameActions.help)
            {
                IViewInterfaceForHelp viewAllRezults =
                    dGetViews(typeof(IViewInterfaceForHelp)) as IViewInterfaceForHelp;

                IModelHelpInterface helpModel = new ModelHelp();

                new HelpController(viewAllRezults, helpModel).Start();
                
                return;//!!!!!!!!!!!!
            }


            _model.ActionOnFigure(parAction);
        }


        /// <summary>
        /// Метод вызывается когда изменились настройки в окне настроек
        /// </summary>
        /// <param name="parObject"></param>
        /// <param name="parSettingDTO">Новые настройки</param>
        void SettingChanged(Object parObject, SettingDTO parSettingDTO)
        {
            _model.GameBox.CreateNewBord(parSettingDTO);
        }

    }
}
