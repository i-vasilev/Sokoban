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
    /// Контроллер консольного окна новой записи
    /// </summary>
    public class ControllerNewRecordConsole : ControllerNewRecord
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии ввода нового рекорда
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parScore"></param>
        public ControllerNewRecordConsole(int parScore) : base(parScore)
        {
            IsNewHighscore = ModelHighscores.Highscores.Count < 10;
            if (!IsNewHighscore)
            {
                foreach (var item in ModelHighscores.Highscores)
                {
                    if (item.Score >= Model.Score)
                    {
                        IsNewHighscore = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public override void Start()
        {
            View = new ViewNewRecordConsole();
            View.StartDrawing();
            if (IsNewHighscore)
            {
                string name = Console.ReadLine();
                Model.Name = name;
                ModelHighscores.Highscores.Add(Model);
                ModelHighscores.WriteFile();
            }
            Close?.Invoke();
        }
    }
}
