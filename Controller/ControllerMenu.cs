using Model;
using System;
using View;

namespace Controller
{
    /// <summary>
    /// Класс контроллера главного меню
    /// </summary>
    public abstract class ControllerMenu
    {
        /// <summary>
        /// Поле модели главного меню
        /// </summary>
        private Model.ModelMainMenu _model;
        /// <summary>
        /// Поле view главного меню
        /// </summary>
        private View.ViewMainMenu _view;

        /// <summary>
        /// Модель главного меню
        /// </summary>
        protected Model.ModelMainMenu Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /// <summary>
        /// View главного меню
        /// </summary>
        protected View.ViewMainMenu View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

        /// <summary>
        /// Делегат события выбора пункта меню
        /// </summary>
        /// <param name="parItem">Номер выбранного пункта меню</param>
        /// <param name="parController">Текущий объект</param>
        public delegate void DChoosedMenuItem(int parItem, ControllerMenu parController);

        /// <summary>
        /// Конструктор контроллера меню
        /// </summary>
        public ControllerMenu()
        {
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public abstract void Start();

    }
}
