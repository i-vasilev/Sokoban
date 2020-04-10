using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    /// <summary>
    /// Общий класс контроллера инструкции 
    /// </summary>
    public abstract class ControllerInstruction
    {
        /// <summary>
        /// Модель инструкции
        /// </summary>
        public ModelInstruction Model;

        /// <summary>
        /// View инструкции
        /// </summary>
        public ViewInstruction View;

        /// <summary>
        /// Старт отслеживания нажатия клавиши
        /// </summary>
        public abstract void Start();
    }
}
