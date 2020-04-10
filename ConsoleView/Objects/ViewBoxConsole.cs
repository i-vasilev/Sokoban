using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Класс вывода коробки в консоль
    /// </summary>
    class ViewBoxConsole : ViewGameObectConsole
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewBoxConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод стенки в консоль
        /// </summary>
        /// <param name="parGameObject">Стенка</param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("▄▄▄", "▀▀▀", parGameObject, ConsoleColor.Yellow);
        }
    }
}
