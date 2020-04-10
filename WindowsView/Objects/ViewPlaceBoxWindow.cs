using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace WindowsView.Objects
{
    /// <summary>
    /// Класс вывода места для коробки на форму
    /// </summary>
    class ViewPlaceBoxWindow : ViewGameObjectWindow
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewPlaceBoxWindow(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
            PenOutp = new Pen(Color.Green, 3);
        }

        /// <summary>
        /// Вывод места для коробки на форму
        /// </summary>
        /// <param name="parGameObject">Место для коробки</param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY;
            BufferedGraphicsOutp.Graphics.DrawRectangle(PenOutp, new Rectangle(x + 2, y + 2, 26, 26));
        }
    }
}
