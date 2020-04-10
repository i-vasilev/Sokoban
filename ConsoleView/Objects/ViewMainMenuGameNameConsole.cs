using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Objects;

namespace ConsoleView
{
    /// <summary>
    /// Класс вывода названия в консоль
    /// </summary>
    class ViewMainMenuGameNameConsole : ViewMainMenuGameName
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Начальная x координата</param>
        /// <param name="parOffsetY">Начальная у координата</param>
        public ViewMainMenuGameNameConsole(int parOffsetX, int parOffsetY) : base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода
        /// </summary>
        public override void Draw()
        {
            int i = OffsetY;
            FastOutput.Write(" ////     ////  //  //   ////   ////      //// ////  //", OffsetX, i++, ConsoleColor.Yellow);
            FastOutput.Write("//     //   /// // //  //   // //  //    // // // // //", OffsetX, i++, ConsoleColor.Yellow);
            FastOutput.Write(" //    //   /// ////   //   // /////    //  // //  ////", OffsetX, i++, ConsoleColor.Yellow);
            FastOutput.Write("  //   //   /// // //  //   // //  //   ////// //   ///", OffsetX, i++, ConsoleColor.Yellow);
            FastOutput.Write("   //  //   /// //  //  //  // //  //  //   // //    //", OffsetX, i++, ConsoleColor.Yellow);
            FastOutput.Write("////    /////   //   //  ////  /////  //    // //    //", OffsetX, i++, ConsoleColor.Yellow);
        }
    }
}
