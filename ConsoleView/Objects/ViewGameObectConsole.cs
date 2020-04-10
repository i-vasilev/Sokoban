using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;
using View.Objects;

namespace ConsoleView.Objects
{
    /// <summary>
    /// Абстрактный класс вывода игрового обекта в консоль
    /// </summary>
    public abstract class ViewGameObectConsole : ViewGameObject
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewGameObectConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        /// <param name="parTop">Верхняя строка объекта</param>
        /// <param name="parBottom">Нижняя строка объекта</param>
        /// <param name="gameObject">Игровой объект</param>
        /// <param name="parColor">Цвет вывода</param>
        protected void PrintObject(String parTop, String parBottom, GameObject gameObject, ConsoleColor parColor)
        {
            int x = gameObject.X * ViewGameConsole.WIDTH_GAME_OBJECT + OffsetX;
            int y = gameObject.Y * ViewGameConsole.HEIGHT_GAME_OBJECT + OffsetY;

            FastOutput.Write(parTop, x, y, parColor);
            FastOutput.Write(parBottom, x, y + 1, parColor);
        }
    }
}
