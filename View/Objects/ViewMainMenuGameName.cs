using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Objects
{
    /// <summary>
    /// Общий класс вывода названия игры
    /// </summary>
    public abstract class ViewMainMenuGameName:ViewObject
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси Х</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        public ViewMainMenuGameName(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода одного объекта
        /// </summary>
        /// <param name="gameObject">Объект для вывода</param>
        public abstract void Draw();
    }
}
