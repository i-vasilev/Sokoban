using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsView;
using Model;

namespace WindowsController
{
    /// <summary>
    /// Контроллер окна нового рекорда
    /// </summary>
    class ControllerNewRecordWindows : ControllerNewRecord
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии ввода нового рекорда
        /// </summary>
        public event ModelGame.dEventHandler Close;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parScore"></param>
        public ControllerNewRecordWindows(int parScore) : base(parScore)
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
        /// Старт вывода нового рекорда
        /// </summary>
        public override void Start()
        {
            if (IsNewHighscore)
            {
                View = new ViewNewRecordWindows();
                ((ViewNewRecordWindows)View).PressedEnter += ControllerNewRecordWindows_PressedEnter;
                View.StartDrawing();
            }
            else
            {
                Close?.Invoke();
            }
        }

        /// <summary>
        /// Нажата кнопка enter.
        /// </summary>
        /// <param name="parEnter"></param>
        private void ControllerNewRecordWindows_PressedEnter(string parEnter)
        {
            Model.Name = parEnter;
            View.StopDrawing();
            ModelHighscores.Highscores.Add(Model);
            ModelHighscores.WriteFile();
            Close?.Invoke();
        }
    }
}
