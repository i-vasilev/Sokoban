using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ConsoleView;

namespace ConsoleController
{
    /// <summary>
    /// Класс контроллер таблицы рекордов консольного режима
    /// </summary>
    public class ControllerHighscoreConsole : ControllerHighscores
    {
        /// <summary>
        /// Событие закрытия таблицы рекордов
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ControllerHighscoreConsole()
        {
            Model = new Model.ModelHighcores();
            View = new ViewHighscoreConsole(Model);
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
