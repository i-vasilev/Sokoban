using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Objects
{
    /// <summary>
    /// Класс для всех классов вывода объектов.
    /// </summary>
    public abstract class ViewObject
    {
        /// <summary>
        /// Смещение объекта по оси X
        /// </summary>
        private int _offsetX;
        /// <summary>
        /// Смещение объекта по оси Y
        /// </summary>
        private int _offsetY;

        /// <summary>
        /// Смещение объекта по оси X
        /// </summary>
        protected int OffsetX { get => _offsetX; set => _offsetX = value; }
        /// <summary>
        /// Смещение объекта по оси Y
        /// </summary>
        protected int OffsetY { get => _offsetY; set => _offsetY = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси Х</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        public ViewObject(int parOffsetX, int parOffsetY)
        {
            OffsetX = parOffsetX;
            OffsetY = parOffsetY;
        }
    }
}
