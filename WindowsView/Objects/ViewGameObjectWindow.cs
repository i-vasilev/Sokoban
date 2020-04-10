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
    /// Абстрактный класс вывода игрового обекта на форму
    /// </summary>
    public abstract class ViewGameObjectWindow:ViewGameObject
    {
        /// <summary>
        /// Объект двойной буфферизации
        /// </summary>
        protected BufferedGraphics BufferedGraphicsOutp;
        /// <summary>
        /// Кисть вывода
        /// </summary>
        protected Brush BrushOutp;
        /// <summary>
        /// Pen вывода
        /// </summary>
        protected Pen PenOutp;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parBufferedGraphics">Объект двойной буфферизации</param>
        /// <param name="parOffsetX">Позиция X вывода</param>
        /// <param name="parOffsetY">Позиция X вывода</param>
        public ViewGameObjectWindow(BufferedGraphics parBufferedGraphics, int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
            BufferedGraphicsOutp = parBufferedGraphics;
        }
    }
}
