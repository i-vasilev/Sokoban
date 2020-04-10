using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Controller;
using WindowsView;
using System.Windows.Forms;

namespace WindowsController
{
    /// <summary>
    /// Контроллер windows игры
    /// </summary>
    public class ControllerGameWindow : ControllerGame
    {
        /// <summary>
        /// Событие, вызывающееся при выигрыше игры
        /// </summary>
        public event Model.ModelGame.dEventHandler GameWin;
        /// <summary>
        /// Событие, вызывающееся при выходе в меню
        /// </summary>
        public event Model.ModelGame.dEventHandler GameClose;

        /// <summary>
        /// Конструктор контроллера игры
        /// </summary>
        /// <param name="parGameForm">Форма вывода игры</param>
        public ControllerGameWindow()
        {
            ModelGame = new Model.ModelGame();
            ModelGame.GameWin += _modelGame_GameWin;
            ViewGame = new WindowsView.ViewGameWindow(ModelGame);
            ((ViewGameWindow)ViewGame).KeyDown += ControllerGameWindow_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerGameWindow_KeyDown(KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case Keys.Down:
                    ModelGame.MoveHero("down");
                    break;
                case Keys.Up:
                    ModelGame.MoveHero("up");
                    break;
                case Keys.Left:
                    ModelGame.MoveHero("left");
                    break;
                case Keys.Right:
                    ModelGame.MoveHero("right");
                    break;
                case Keys.Enter:
                    ViewGame.StopGame();
                    GameClose?.Invoke();
                    break;
            }
        }

        /// <summary>
        /// Обработчик события победы в игре
        /// </summary>
        private void _modelGame_GameWin()
        {
            this.GameWin?.Invoke();
            ModelGame.GameWin -= (Model.ModelGame.dEventHandler)_modelGame_GameWin;
        }
    }
}
