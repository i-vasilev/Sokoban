using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Класс вывода главного героя на консоль
    /// </summary>
    class ViewHeroConsole : ViewGameObectConsole
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewHeroConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Выводит главного героя на экран
        /// </summary>
        /// <param name="parGameObject"></param>
        public override void Draw(GameObject parGameObject)
        {
            PrintObject("* *", "===", parGameObject, ConsoleColor.White);
        }
    }
}
