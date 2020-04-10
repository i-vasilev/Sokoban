using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Класс вывода инструкции на консоль
    /// </summary>
    public class ViewInstructionConsole : ViewInstruction
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModel">Модель инструкции</param>
        public ViewInstructionConsole(ModelInstruction parModel) : base(parModel)
        {
            StartDrawing();
        }

        /// <summary>
        /// Метод вывода инструкции на консоль
        /// </summary>
        public override void ShowInstruction()
        {
            while (true)
            {
                FastOutput.Clear();
                FastOutput.Write(Model.TextInstruction, 1, 1, ConsoleColor.Yellow);
                FastOutput.PrintOnConsole();
            }
        }

        /// <summary>
        /// Остановка вывода таблицы рекордов
        /// </summary>
        public override void StopView()
        {
            ThreadView.Abort();
        }
    }
}
