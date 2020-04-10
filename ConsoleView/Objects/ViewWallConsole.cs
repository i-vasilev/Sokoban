using Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Класс вывода стены в консоль
    /// </summary>
    class ViewWallConsole : ViewGameObectConsole
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewWallConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод стенки в консоль
        /// </summary>
        /// <param name="parGameObject">Стена</param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("███", "███", parGameObject, ConsoleColor.Red);
        }

    }
}
