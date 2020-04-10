using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Objects;

namespace WindowsView.Objects
{
    /// <summary>
    /// Класс вывода названия игры на форму
    /// </summary>
    class ViewMainMenuGameNameWindow : ViewMainMenuGameName
    {
        /// <summary>
        /// Строка вывода
        /// </summary>
        private const string GAME_NAME = "SOKOBAN";
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private const int FONT_SIZE = 100;
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Начало вывода строки по X</param>
        /// <param name="parOffsetY">Начало вывода строки по Y</param>
        /// <param name="parBufferedGraphics">Объект двойной буферизации</param>
        public ViewMainMenuGameNameWindow(int parOffsetX, int parOffsetY, BufferedGraphics parBufferedGraphics) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
        }

        /// <summary>
        /// Метод вывода
        /// </summary>
        public override void Draw()
        {
            Font font = new Font(FontFamily.GenericMonospace, FONT_SIZE, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Yellow);
            _bufferedGraphics.Graphics.DrawString(GAME_NAME, font, brush, OffsetX, OffsetY);
        }
    }
}
