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
    /// Класс контроллер таблицы рекордов
    /// </summary>
    public abstract class ControllerHighscores
    {
        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        public ModelHighcores Model;
        
        /// <summary>
        /// View таблицы рекордов
        /// </summary>
        public ViewHighscores View;
        
        /// <summary>
        /// Старт отслеживания нажатия клавиши
        /// </summary>
        public abstract void Start();
    }
}
