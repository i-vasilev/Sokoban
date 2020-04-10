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
    /// Класс вывода стены на форму
    /// </summary>
    public class ViewWallWindows : ViewGameObjectWindow
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewWallWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
            BrushOutp = new SolidBrush(Color.Brown);
            PenOutp = new Pen(Color.RosyBrown, 1);
        }

        /// <summary>
        /// Вывод стенки на форму
        /// </summary>
        /// <param name="parGameObject"></param>
        public override void Draw(GameObject parGameObject)
        {
            int x = parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX;
            int y = parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY;
            BufferedGraphicsOutp.Graphics.FillRectangle(BrushOutp, new Rectangle(x, y, ViewGameWindow.SIZE_GAME_OBJECT, ViewGameWindow.SIZE_GAME_OBJECT));
            BufferedGraphicsOutp.Graphics.DrawLine(PenOutp, new Point(x, y), new Point(x + ViewGameWindow.SIZE_GAME_OBJECT, y + ViewGameWindow.SIZE_GAME_OBJECT));
            BufferedGraphicsOutp.Graphics.DrawLine(PenOutp, new Point(x, y + ViewGameWindow.SIZE_GAME_OBJECT), new Point(x + ViewGameWindow.SIZE_GAME_OBJECT, y));
            BufferedGraphicsOutp.Graphics.DrawRectangle(PenOutp, new Rectangle(x, y, ViewGameWindow.SIZE_GAME_OBJECT, ViewGameWindow.SIZE_GAME_OBJECT));
        }
    }
}
