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
    /// Общий класс вывода нового рекорда
    /// </summary>
    public abstract class ViewNewRecord
    {
        /// <summary>
        /// Строка нового рекорда
        /// </summary>
        protected const string STRING_NEW_RECORD = "Новый рекорд! Введите своё имя и нажмите Enter";
        /// <summary>
        /// Поток вывода
        /// </summary>
        private Thread _threadView;

        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        private object _locker = new object();

        /// <summary>
        /// Поток вывода
        /// </summary>
        public Thread ThreadView { get => _threadView; set => _threadView = value; }
        /// <summary>
        /// Объект блокировщик потока вывода
        /// </summary>
        protected object Locker { get => _locker; set => _locker = value; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewNewRecord() { }

        /// <summary>
        /// Стартует поток вывода
        /// </summary>
        public void StartDrawing()
        {
            ThreadView = new Thread(Draw);
            ThreadView.Start();
        }

        /// <summary>
        /// Остановка вывода
        /// </summary>
        public abstract void StopDrawing();

        /// <summary>
        /// Метод рисования
        /// </summary>
        protected abstract void Draw();
    }
}
