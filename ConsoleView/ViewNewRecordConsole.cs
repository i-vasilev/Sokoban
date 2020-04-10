using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Класс вывода окна нового рекорда
    /// </summary>
    public class ViewNewRecordConsole : ViewNewRecord
    {
        /// <summary>
        /// Конструктор класса вывода
        /// </summary>
        public ViewNewRecordConsole() : base()
        { }

        /// <summary>
        /// Окончание вывода
        /// </summary>
        public override void StopDrawing()
        { }

        /// <summary>
        /// Метод рисования
        /// </summary>
        protected override void Draw()
        {
            FastOutput.Clear();
            FastOutput.Write(STRING_NEW_RECORD, 10, 4, ConsoleColor.Blue);
            FastOutput.PrintOnConsole();
            Console.SetCursorPosition(15, 15);
        }
    }
}
