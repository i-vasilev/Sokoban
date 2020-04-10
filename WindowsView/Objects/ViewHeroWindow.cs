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
    /// Класс вывода главного героя на экран
    /// </summary>
    public class ViewHeroWindow : ViewGameObjectWindow
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewHeroWindow(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parBufferedGraphics, parOffsetX, parOffsetY)
        {
            BrushOutp = new SolidBrush(Color.Red);
            PenOutp = new Pen(BrushOutp, 2);
        }

        /// <summary>
        /// Вывод героя на форму
        /// </summary>
        /// <param name="parGameObject"></param>
        public override void Draw(GameObject parGameObject)
        {
            BufferedGraphicsOutp.Graphics.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(
                parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX,
                parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY,
                ViewGameWindow.SIZE_GAME_OBJECT,
                ViewGameWindow.SIZE_GAME_OBJECT));
            BufferedGraphicsOutp.Graphics.FillEllipse(new SolidBrush(Color.Green), new Rectangle(
                parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 7,
                parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 7,
                5,
                5));
            BufferedGraphicsOutp.Graphics.FillEllipse(new SolidBrush(Color.Green), new Rectangle(
                parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 17,
                parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 7,
                5,
                5));
            Point[] points = new Point[4];
            points[0] = new Point(parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 7, parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 20);
            points[1] = new Point(parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 18, parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 25);
            points[2] = new Point(parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 25, parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 20);
            points[3] = new Point(parGameObject.X * ViewGameWindow.SIZE_GAME_OBJECT + OffsetX + 25, parGameObject.Y * ViewGameWindow.SIZE_GAME_OBJECT + OffsetY + 20);
            BufferedGraphicsOutp.Graphics.DrawBezier(PenOutp, points[0], points[1], points[2], points[3]);
        }
    }
}
