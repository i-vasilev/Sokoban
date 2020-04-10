using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    /// <summary>
    /// Класс, представляющий ящик в игре
    /// </summary>
    public class Box : GameObject
    {
        /// <summary>
        /// Конструктор ящика
        /// </summary>
        /// <param name="parX">Позиция ящика по X</param>
        /// <param name="parY">Позиция ящика по Y</param>
        public Box(int parX, int parY) : base(parX, parY)
        {
        }
    }
}
