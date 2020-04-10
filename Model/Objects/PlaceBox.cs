using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    /// <summary>
    /// Класс, представляющий место для ящика в игре
    /// </summary>
    public class PlaceBox : GameObject
    {
        /// <summary>
        /// Конструктор места для ящика
        /// </summary>
        /// <param name="parX">Позиция места для ящика по X</param>
        /// <param name="parY">Позиция места для ящика по Y</param>
        public PlaceBox(int parX, int parY) : base(parX, parY)
        {
        }
    }
}
