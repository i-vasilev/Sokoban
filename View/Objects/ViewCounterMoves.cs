using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Objects
{
    /// <summary>
    /// Класс вывода счетчика ходов
    /// </summary>
    public abstract class ViewCounterMoves:ViewObject
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение по оси X</param>
        /// <param name="parOffsetY">Смещение по оси Y</param>
        public ViewCounterMoves(int parOffsetX, int parOffsetY):base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Выводит счетчик
        /// </summary>
        /// <param name="parCountMoves">количество перемещений</param>
        public abstract void Draw(int parCountMoves);
    }
}
