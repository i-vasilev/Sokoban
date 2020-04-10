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
    /// Класс вывода счетчика ходов
    /// </summary>
    public class ViewCounterMovesWindows : ViewCounterMoves
    {
        /// <summary>
        /// Точка начала вывода строки по Х
        /// </summary>
        private const int X_STRING = 600;
        /// <summary>
        /// Точка начала вывода строки по у
        /// </summary>
        private const int Y_STRING = 150;
        /// <summary>
        /// Размер шрифта
        /// </summary>
        private const int FONT_SIZE = 13;
        /// <summary>
        /// Кисть вывода
        /// </summary>
        private readonly Brush _brush;
        /// <summary>
        /// Pen вывода
        /// </summary>
        private readonly Pen _pen;
        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        private readonly BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        public ViewCounterMovesWindows(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            _bufferedGraphics = parBufferedGraphics;
            _brush = new SolidBrush(Color.Gray);
            _pen = new Pen(Color.LightBlue);
        }

        /// <summary>
        /// Вывод счётчика на форму
        /// </summary>
        /// <param name="parCountMoves">Количество перемещений</param>
        public override void Draw(int parCountMoves)
        {
            _bufferedGraphics.Graphics.DrawString("Количество ходов: " + parCountMoves, new Font("Arial", FONT_SIZE), _brush, X_STRING, Y_STRING);
        }
    }
}
