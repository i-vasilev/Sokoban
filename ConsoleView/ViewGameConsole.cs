using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;
using Model.Objects;
using View;
using ConsoleView.Objects;
using WindowsView.Objects.Factories;
using View.Objects.Factories;

namespace ConsoleView
{
    /// <summary>
    /// Класс вывода игры на консоль
    /// </summary>
    public class ViewGameConsole : ViewGame
    {
        /// <summary>
        /// Ширина консоли
        /// </summary>
        private const int WIDTH_CONSOLE = 80;
        /// <summary>
        /// Высота консоли
        /// </summary>
        private const int HEIGHT_CONSOLE = 25;
        /// <summary>
        /// Таймаут обновления игры
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Ширина игрового объекта
        /// </summary>
        public const int WIDTH_GAME_OBJECT = 3;
        /// <summary>
        /// Высота игрового объекта
        /// </summary>
        public const int HEIGHT_GAME_OBJECT = 2;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGameConsole(ModelGame parModelGame) : base(parModelGame)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            ModelGame.ReadyToPlay += _modelGame_ReadyToPlay;
        }

        /// <summary>
        /// Обработчик события готовности модели к игре
        /// </summary>
        private void _modelGame_ReadyToPlay()
        {
            ThreadView = new Thread(ShowGame);
            ThreadView.Start();
        }

        /// <summary>
        /// Основной метод вывода игры на окно
        /// </summary>
        protected override void ShowGame()
        {
            Console.SetWindowSize(WIDTH_CONSOLE, HEIGHT_CONSOLE);
            int offsetX = (Console.WindowWidth - ModelGame.Field.Width * WIDTH_GAME_OBJECT) / 2;
            int offsetY = (Console.WindowHeight - ModelGame.Field.Height * HEIGHT_GAME_OBJECT) / 2;
            ViewGameObectConsole viewBoxConsole = ViewGameObjectConsoleFactory.CreateView(TypesView.ViewBox, offsetX, offsetY);
            ViewGameObectConsole viewPlaceBoxConsole = ViewGameObjectConsoleFactory.CreateView(TypesView.ViewPlaceBox, offsetX, offsetY);
            ViewGameObectConsole viewWallConsole = ViewGameObjectConsoleFactory.CreateView(TypesView.ViewWall, offsetX, offsetY);
            ViewGameObectConsole viewHeroConsole = ViewGameObjectConsoleFactory.CreateView(TypesView.ViewHero, offsetX, offsetY);
            ViewCounterMovesConsole viewCounterMoves = new ViewCounterMovesConsole(offsetX, offsetY);
            while (true)
            {
                Thread.Sleep(MILLISECONDS_TIMEOUT);
                lock (Locker)
                {
                    FastOutput.Clear();
                    viewWallConsole.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is Wall)));
                    viewPlaceBoxConsole.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is PlaceBox)));
                    viewBoxConsole.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is Box)));
                    viewHeroConsole.Draw(ModelGame.Hero);
                    viewCounterMoves.Draw(ModelGame.CounterMoves);
                }
                FastOutput.PrintOnConsole();
            }
        }
    }
}
