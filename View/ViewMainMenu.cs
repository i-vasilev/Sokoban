using Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace View
{
    /// <summary>
    /// Общий класс вывода главного меню
    /// </summary>
    public abstract class ViewMainMenu
    {
        /// <summary>
        /// Позиция Х вывода главного меню
        /// </summary>
        private int _x;
        /// <summary>
        /// Ширина пунктов главного меню
        /// </summary>
        private int _width;
        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        private object _locker = new object();
        /// <summary>
        /// Поток вывода
        /// </summary>
        private Thread _threadView;
        /// <summary>
        /// Модель меню
        /// </summary>
        private ModelMainMenu _modelMenu;

        /// <summary>
        /// Позиция Х вывода главного меню
        /// </summary>
        protected int X { get => _x; set => _x = value; }
        /// <summary>
        /// Ширина пунктов главного меню
        /// </summary>
        protected int Width { get => _width; set => _width = value; }
        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get => _locker; set => _locker = value; }
        /// <summary>
        /// Поток вывода
        /// </summary>
        public Thread ThreadView { get => _threadView; set => _threadView = value; }
        /// <summary>
        /// Модель меню
        /// </summary>
        public ModelMainMenu ModelMenu { get => _modelMenu; set => _modelMenu = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ViewMainMenu()
        {
        }

        /// <summary>
        /// Стартует поток вывода
        /// </summary>
        public abstract void StartDrawing();

        /// <summary>
        /// Метод вывода меню
        /// </summary>
        public abstract void ShowMenu();

    }
}
