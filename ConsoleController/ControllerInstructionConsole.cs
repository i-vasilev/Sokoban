using ConsoleView;
using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController
{
    /// <summary>
    /// Класс контроллер инструкции консольного режима
    /// </summary>
    public class ControllerInstructionConsole : ControllerInstruction
    {
        /// <summary>
        /// Событие закрытия таблицы рекордов
        /// </summary>
        public event ModelGame.dEventHandler Close;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ControllerInstructionConsole()
        {
            Model = new ModelInstruction();
            View = new ViewInstructionConsole(Model);
        }

        /// <summary>
        /// Старт отслеживания нажатия клавиши
        /// </summary>
        public override void Start()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                bool isEnter = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        View.StopView();
                        isEnter = true;
                        Close?.Invoke();
                        break;
                }
                if (isEnter)
                {
                    break;
                }
            }
        }
    }
}
