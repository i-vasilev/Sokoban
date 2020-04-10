using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Controller;
using Model;

namespace ConsoleController
{
    /// <summary>
    /// Класс контроллера главного меню
    /// </summary>
    public class ControllerMainMenuConsole : ControllerMenu
    {
        /// <summary>
        /// Instance контроллера
        /// </summary>
        private static ControllerMainMenuConsole _instance;
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
        /// Конструктор контроллера
        /// </summary>
        private ControllerMainMenuConsole()
        {
            Model = new Model.ModelMainMenu();
            Model.ListStates.Add(new Model.ModelMenuItem(PLAY_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerGameConsole controller = new ControllerGameConsole();
                controller.GameWin += new ModelGame.dEventHandler(() =>
                {
                    ControllerNewRecordConsole controllerNewRecord = new ControllerNewRecordConsole(controller.ModelGame.CounterMoves);
                    controllerNewRecord.Close += Start;
                    controllerNewRecord.Start();
                });
                controller.GameClose += Start;
                controller.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(TABLE_RECORDS_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerHighscoreConsole highscoreConsole = new ControllerHighscoreConsole();
                highscoreConsole.Close += Start;
                highscoreConsole.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(INSTRUCTIONS_NAME, new ModelMenuItem.DDoAction(() =>
            {
                ControllerInstructionConsole instructionConsole = new ControllerInstructionConsole();
                instructionConsole.Close += Start;
                instructionConsole.Start();
            })));
            Model.ListStates.Add(new ModelMenuItem(EXIT_NAME, new ModelMenuItem.DDoAction(() => { })));
            View = new ConsoleView.ViewMainMenuConsole
            {
                ModelMenu = Model
            };
        }

        /// <summary>
        /// Старт игры
        /// </summary>
        public override void Start()
        {
            View.StartDrawing();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                bool isEnter = false;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        isEnter = true;
                        ((ConsoleView.ViewMainMenuConsole)View).StopShowing();
                        Model.DoActualAction();
                        break;
                    case ConsoleKey.UpArrow:
                        Model.ActualState--;
                        break;
                    case ConsoleKey.DownArrow:
                        Model.ActualState++;
                        break;
                    default:
                        break;
                }
                if (isEnter)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Создание и возврат Instance
        /// </summary>
        /// <returns>Instance</returns>
        public static ControllerMainMenuConsole GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ControllerMainMenuConsole();
            }
            return _instance;
        }
    }
}
