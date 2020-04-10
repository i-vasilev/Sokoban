using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{

    /// <summary>
    /// Герой на игровом поле
    /// </summary>
    public class Hero : GameObject
    {
        /// <summary>
        /// Конструктор героя
        /// </summary>
        /// <param name="parX">Позиция героя по X</param>
        /// <param name="parY">Позиция героя по Y</param>
        public Hero(int parX, int parY) : base(parX, parY)
        {
        }
    }
}
