using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Общий класс вывода таблицы рекордов на экран
    /// </summary>
    public abstract class ViewHighscores
    {
        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        private ModelHighcores _model;

        /// <summary>
        /// Поток вывода таблицы рекордов
        /// </summary>
        private Thread _threadView;

        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        private object _locker;

        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        protected ModelHighcores Model { get => _model; set => _model = value; }
        /// <summary>
        /// Поток вывода таблицы рекордов
        /// </summary>
        protected Thread ThreadView { get => _threadView; set => _threadView = value; }
        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get => _locker; set => _locker = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModel">Модель таблицы рекордов</param>
        public ViewHighscores(ModelHighcores parModel)
        {
            Locker = new object();
            Model = parModel;
        }

        /// <summary>
        /// Метод остановки вывода
        /// </summary>
        public abstract void StopView();

        /// <summary>
        /// Метод вывода таблицы рекордов
        /// </summary>
        public abstract void ShowHighscores();
    }
}
