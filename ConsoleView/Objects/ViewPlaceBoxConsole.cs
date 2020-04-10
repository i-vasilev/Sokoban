using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Класс вывода места для коробки в консоль
    /// </summary>
    class ViewPlaceBoxConsole : ViewGameObectConsole
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewPlaceBoxConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод места для коробки в консоль
        /// </summary>
        /// <param name="parGameObject">Место для коробки</param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("┌─┐", "└─┘", parGameObject, ConsoleColor.Green);
        }
    }
}
