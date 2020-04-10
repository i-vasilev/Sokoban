using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс модели главного меню
    /// </summary>
    public class ModelMainMenu
    {
        /// <summary>
        /// Номер выбранного пункта меню
        /// </summary>
        private int _actualState;

        /// <summary>
        /// Список пунктов меню
        /// </summary>
        private List<ModelMenuItem> _listStates;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ModelMainMenu()
        {
            ListStates = new List<ModelMenuItem>();
        }

        /// <summary>
        /// Список пунктов меню
        /// </summary>
        public List<ModelMenuItem> ListStates
        {
            get { return _listStates; }
            set { _listStates = value; }
        }

        /// <summary>
        /// Номер выбранного пункта меню
        /// </summary>
        public int ActualState
        {
            get
            {
                return _actualState;
            }
            set
            {
                if (value >= 0 && ((int)value) < ListStates.Count)
                {
                    _actualState = value;
                }
                else
                {
                    if (value<0)
                    {
                        _actualState = ListStates.Count - 1;
                    }
                    else
                    {
                        _actualState = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Выполнить действие привязанное к выбранному пункту меню
        /// </summary>
        public void DoActualAction()
        {
            ListStates[ActualState].Action();
        }
    }
}
