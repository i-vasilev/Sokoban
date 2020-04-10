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
    /// Общий класс вывода инструкции 
    /// </summary>
    public abstract class ViewInstruction
    {
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
        private ModelInstruction _model;

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
        public ModelInstruction Model { get => _model; set => _model = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ViewInstruction(ModelInstruction parModel)
        {
            Model = parModel;
        }

        /// <summary>
        /// Стартует поток вывода
        /// </summary>
        public void StartDrawing()
        {
            ThreadView = new Thread(ShowInstruction);
            ThreadView.Start();
        }

        /// <summary>
        /// Остановка потока вывода
        /// </summary>
        public virtual void StopView()
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Метод вывода инструкции 
        /// </summary>
        public abstract void ShowInstruction();
    }
}
