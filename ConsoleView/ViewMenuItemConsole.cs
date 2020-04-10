using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Класс вывода меню в консоль
    /// </summary>
    public class ViewMenuItemConsole : ViewMenuItem
    {
        /// <summary>
        /// Ширина пунктов меню
        /// </summary>
        private const int WIDTH=30;
        /// <summary>
        /// Смещение пунктов меню
        /// </summary>
        private const int OFFSET_ITEM = 4;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Позиция X</param>
        /// <param name="parY">Позиция Y</param>
        public ViewMenuItemConsole(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Метод вывода всех пунктов меню в консоль
        /// </summary>
        /// <param name="parListStates">Список пунктов меню</param>
        /// <param name="parActualState">Активный элемент</param>
        public override void DrawAllItems(List<Model.ModelMenuItem> parListStates, int parActualState)
        {
            var yDraw = Y;
            for (int i = 0; i <parListStates.Count; i++)
            {
                ConsoleColor color;
                if (i == parActualState)
                {
                    color = ConsoleColor.Cyan;
                }
                else
                {
                    color = ConsoleColor.Red;
                }
                Print(parListStates[i].Text, yDraw, color);
                yDraw += OFFSET_ITEM;
            }
        }

        /// <summary>
        /// Вывод пункта меню в консоль
        /// </summary>
        /// <param name="parText">Текст пункта меню</param>
        /// <param name="parY">Позиция Y</param>
        /// <param name="parColor">Цвет</param>
        private void Print(string parText, int parY, ConsoleColor parColor)
        {
            string top = "╔" + "".PadRight(WIDTH, '═') + "╗";
            string bottom = "╚" + "".PadRight(WIDTH, '═') + "╝";
            parText = "║" + parText.PadLeft(parText.Length + (WIDTH - parText.Length) / 2, ' ').PadRight((WIDTH), ' ') + "║";
            FastOutput.Write(top, X, parY, parColor);
            FastOutput.Write(parText, X, parY + 1, parColor);
            FastOutput.Write(bottom, X, parY + 2, parColor);
        }
    }
}
