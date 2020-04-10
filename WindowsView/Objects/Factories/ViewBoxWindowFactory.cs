using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Objects;
using View.Objects.Factories;

namespace WindowsView.Objects.Factories

{
    /// <summary>
    /// Абстрактная фабрика View
    /// </summary>
    public abstract class ViewBoxWindowFactory
    {
        /// <summary>
        /// Создает ViewGameObjectWindow типа, который передан.
        /// </summary>
        /// <param name="parType">Тип ViewGameObjectWindow</param>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        /// <returns>Готовый объект</returns>
        public static ViewGameObjectWindow CreateView(TypesView parType, int parOffsetX, int parOffsetY, BufferedGraphics parBufferedGraphics)
        {
            switch (parType)
            {
                case TypesView.ViewBox:
                    return new ViewBoxWindow(parBufferedGraphics, parOffsetX, parOffsetY);
                case TypesView.ViewHero:
                    return new ViewHeroWindow(parBufferedGraphics, parOffsetX, parOffsetY);
                case TypesView.ViewPlaceBox:
                    return new ViewPlaceBoxWindow(parBufferedGraphics, parOffsetX, parOffsetY);
                case TypesView.ViewWall:
                    return new ViewWallWindows(parBufferedGraphics, parOffsetX, parOffsetY);
                default:
                    return null;
            }
        }
    }
}
