using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsView;
using static Model.ModelGame;

namespace WindowsController
{
    /// <summary>
    /// Контроллер таблицы рекордов
    /// </summary>
    class ControllerHighscoresWindow : ControllerHighscores
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии таблицы рекордов
        /// </summary>
        public event dEventHandler Close;

        /// <summary>
        /// Старт таблицы рекордов
        /// </summary>
        public override void Start()
        {
            Model = new ModelHighcores();
            View = new ViewHighscoresWindows(Model);
            ((ViewHighscoresWindows)View).KeyDown += ControllerHighscoresWindow_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerHighscoresWindow_KeyDown(System.Windows.Forms.KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    View.StopView();
                    Close?.Invoke();
                    break;
            }
        }
    }
}
