using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Класс вывода счетчика ходов в консоль
    /// </summary>
    class ViewCounterMovesConsole : ViewCounterMoves
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение по оси X</param>
        /// <param name="parOffsetY">Смещение по оси Y</param>
        public ViewCounterMovesConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Выводит счетчик ходов в консоль
        /// </summary>
        /// <param name="parCountMoves">Количество перемещений</param>
        public override void Draw(int parCountMoves)
        {
            int x = 40 + OffsetX;
            int y = OffsetY;
            FastOutput.Write("Ходов: " + parCountMoves, x, y, ConsoleColor.White);
        }
    }
}
