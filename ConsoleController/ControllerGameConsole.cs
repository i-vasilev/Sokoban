using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleController
{
    /// <summary>
    /// Контроллер консольной игры
    /// </summary>
    public class ControllerGameConsole : Controller.ControllerGame
    {
        /// <summary>
        /// Событие, возникающее при выигрыше
        /// </summary>
        public event Model.ModelGame.dEventHandler GameWin;
        /// <summary>
        /// Событие, вызывающееся при выходе в меню
        /// </summary>
        public event Model.ModelGame.dEventHandler GameClose;

        /// <summary>
        /// Поле для отслеживания, окончания игры
        /// </summary>
        private bool _isPlaying;

        /// <summary>
        /// Конструктор контроллера консольной игры
        /// </summary>
        public ControllerGameConsole()
        {
            ModelGame = new Model.ModelGame();
            ViewGame = new ConsoleView.ViewGameConsole(ModelGame);
            ModelGame.GameWin += _modelGame_GameWin;
            ModelGame.ReadyToPlay += _modelGame_ReadyToPlay;
        }

        /// <summary>
        /// Обработчик события готовности модели к игре
        /// </summary>
        private void _modelGame_ReadyToPlay()
        {
            _isPlaying = true;
            ModelGame.ReadyToPlay -= (Model.ModelGame.dEventHandler)_modelGame_ReadyToPlay;
            while (_isPlaying)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        ModelGame.MoveHero("left");
                        break;
                    case ConsoleKey.UpArrow:
                        ModelGame.MoveHero("up");
                        break;
                    case ConsoleKey.RightArrow:
                        ModelGame.MoveHero("right");
                        break;
                    case ConsoleKey.DownArrow:
                        ModelGame.MoveHero("down");
                        break;
                    case ConsoleKey.Enter:
                        ViewGame.StopGame();
                        GameClose?.Invoke();
                        return;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Обработчик события выигрыша
        /// </summary>
        private void _modelGame_GameWin()
        {
            ModelGame.GameWin -= _modelGame_GameWin;
            ModelGame.ReadyToPlay -= _modelGame_ReadyToPlay;
            _isPlaying = false;
            GameWin?.Invoke();
        }

    }
}
