using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;
using View.Objects;

namespace WindowsView.Objects
{
    /// <summary>
    /// Класс вывода коробки на форму
    /// </summary>
    public class ViewBoxWindow : ViewGameObjectWindow
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewBoxWindow(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
            PenOutp = new Pen(Color.RosyBrown, 2);
            BrushOutp = new SolidBrush(Color.SandyBrown);
        }

        /// <summary>
        /// Вывод стенки на форму
        /// </summary>
        /// <param name="parGameObject">Стенка</param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY;
            BufferedGraphicsOutp.Graphics.FillRectangle(BrushOutp, new Rectangle(x + 4, y + 4, 22, 22));
            BufferedGraphicsOutp.Graphics.DrawLine(PenOutp, new Point(x + 4, y + 4), new Point(x + 24, y + 24));
        }
    }
}
