using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Objects
{
    /// <summary>
    /// Любой объект на игровом поле
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Положение объекта на поле
        /// </summary>
        public int X, Y;

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="parX">Позиция объекта по X</param>
        /// <param name="parY">Позиция объекта по Y</param>
        public GameObject(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }
    }
}
