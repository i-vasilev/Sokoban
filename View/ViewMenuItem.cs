using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Общий класс вывода пункта меню
    /// </summary>
    public abstract class ViewMenuItem
    {
        /// <summary>
        /// Позиция x пункта меню
        /// </summary>
        private int _x;
        /// <summary>
        /// Позиция у пункта меню
        /// </summary>
        private int _y;

        /// <summary>
        /// Позиция x пункта меню
        /// </summary>
        protected int X { get => _x; set => _x = value; }
        /// <summary>
        /// Позиция у пункта меню
        /// </summary>
        protected int Y { get => _y; set => _y = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Позиция x</param>
        /// <param name="parY">Позиция у</param>
        public ViewMenuItem(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Метод вывода всех пунктов меню
        /// </summary>
        /// <param name="parListStates">Список всех пунктов меню</param>
        /// <param name="parActualState">Номер выбранного пункта меню</param>
        public abstract void DrawAllItems(List<Model.ModelMenuItem> parListStates, int parActualState);
    }
}
