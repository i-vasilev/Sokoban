using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    /// <summary>
    /// Стена на игровом поле
    /// </summary>
    public class Wall : GameObject
    {
        /// <summary>
        /// Конструктор стены
        /// </summary>
        /// <param name="parX">Позиция Стены по X</param>
        /// <param name="parY">Позиция Стены по Y</param>
        public Wall(int parX, int parY) : base(parX, parY)
        {
        }
    }
}
