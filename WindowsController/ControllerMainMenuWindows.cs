using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsView;

namespace WindowsController
{
    /// <summary>
    /// Класс контроллера главного меню
    /// </summary>
    public class ControllerMainMenuWindows : ControllerMenu
    {
        /// <summary>
        /// Instance класса
        /// </summary>
        private static ControllerMainMenuWindows _instance;
        /// <summary>
        /// Строка Таблицы рекордов
        /// </summary>
        private const string TABLE_RECORDS_NAME = "Таблица рекордов";
        /// <summary>
        /// Строка Играть
        /// </summary>
        private const string PLAY_NAME = "Играть";
        /// <summary>
        /// Строка Инструкции
        /// </summary>
        private const string INSTRUCTIONS_NAME = "Инструкции";
        /// <summary>
        /// Строка Выход
        /// </summary>
        private const string EXIT_NAME = "Выход";

        /// <summary>
        /// Конструктор класса
        /// </summary>
        private ControllerMainMenuWindows()
        {
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public override void Start()
        {
            Model = new ModelMainMenu();
            Model.ListStates.Add(new ModelMenuItem(PLAY_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerGameWindow controllerGame = new ControllerGameWindow();
                controllerGame.GameWin += new ModelGame.dEventHandler(()=> {
                    ControllerNewRecordWindows controllerNewRecord = new ControllerNewRecordWindows(controllerGame.ModelGame.CounterMoves);
                    controllerNewRecord.Close += Start;
                    controllerNewRecord.Start();
                });
                controllerGame.GameClose += Start;
                controllerGame.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(TABLE_RECORDS_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerHighscoresWindow controllerHighscores = new ControllerHighscoresWindow();
                controllerHighscores.Close += Start;
                controllerHighscores.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(INSTRUCTIONS_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerInstructionWindow controllerInstruction = new ControllerInstructionWindow();
                controllerInstruction.Close += Start;
                controllerInstruction.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(EXIT_NAME, CloseGame));
            View = new WindowsView.ViewMainMenuWindows(Model);
            ((WindowsView.ViewMainMenuWindows)View).KeyDown += ControllerMainMenuWindows_KeyDown;
            View.ModelMenu = Model;
            ((WindowsView.ViewMainMenuWindows)View).StartDrawing();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerMainMenuWindows_KeyDown(System.Windows.Forms.KeyEventArgs parE)
        {
            switch (parE.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    Model.ActualState--;
                    break;
                case System.Windows.Forms.Keys.Down:
                    Model.ActualState++;
                    break;
                case System.Windows.Forms.Keys.Enter:
                    ((WindowsView.ViewMainMenuWindows)View).KeyDown -= (DKeyDown)ControllerMainMenuWindows_KeyDown;
                    ((WindowsView.ViewMainMenuWindows)View).StopShowing();
                    Model.DoActualAction();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Закрытие главного меню
        /// </summary>
        public void CloseGame()
        {
            ((WindowsView.ViewMainMenuWindows)View).CloseGame();
        }

        /// <summary>
        /// Создание и возврат Instance
        /// </summary>
        /// <returns>Instance</returns>
        public static ControllerMainMenuWindows GetInstance()
        {
            if (_instance==null)
            {
                _instance = new ControllerMainMenuWindows();
            }
            return _instance;
        }
    }
}
