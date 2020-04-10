using ConsoleView.Objects;
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
    public abstract class ViewGameObjectConsoleFactory
    {
        /// <summary>
        /// Создает ViewGameObjectConsole типа, который передан.
        /// </summary>
        /// <param name="parType">Тип ViewGameObjectConsole</param>
        /// <param name="parOffsetX">Координата X</param>
        /// <param name="parOffsetY">Координата Y</param>
        /// <returns>Готовый объект</returns>
        public static ViewGameObectConsole CreateView(TypesView parType, int parOffsetX, int parOffsetY)
        {
            switch (parType)
            {
                case TypesView.ViewBox:
                    return new ViewBoxConsole(parOffsetX, parOffsetY);
                case TypesView.ViewHero:
                    return new ViewHeroConsole(parOffsetX, parOffsetY);
                case TypesView.ViewPlaceBox:
                    return new ViewPlaceBoxConsole(parOffsetX, parOffsetY);
                case TypesView.ViewWall:
                    return new ViewWallConsole(parOffsetX, parOffsetY);
                default:
                    return null;
            }
        }
    }
}
