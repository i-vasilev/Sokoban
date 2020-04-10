using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Model;
using System.Threading;

namespace ConsoleView
{
    /// <summary>
    /// Класс для вывода главного меню
    /// </summary>
    public class ViewMainMenuConsole : ViewMainMenu
    {
        /// <summary>
        /// Стартовая позиция начала вывода по высоте
        /// </summary>
        private const int Y = 10;
        /// <summary>
        /// Время обновления
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 100;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ViewMainMenuConsole() : base()
        {
            X = Console.BufferWidth / 2 - 15;
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }

        /// <summary>
        /// Остановка потока вывода в консоль
        /// </summary>
        public void StopShowing()
        {
            ThreadView.Abort();
        }

        /// <summary>
        /// Метод для потока вывода в консоль
        /// </summary>
        public override void ShowMenu()
        {
            ViewMenuItemConsole viewItem = new ViewMenuItemConsole(X, Y);
            ViewMainMenuGameNameConsole viewGameName = new ViewMainMenuGameNameConsole(13, 3);
            while (true)
            {
                lock (Locker)
                {
                    FastOutput.Clear();
                    viewItem.DrawAllItems(ModelMenu.ListStates, ModelMenu.ActualState);
                    viewGameName.Draw();
                    FastOutput.PrintOnConsole();
                    Console.CursorVisible = false;
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }

        /// <summary>
        /// Начало отображения
        /// </summary>
        public override void StartDrawing()
        {
            ThreadView = new Thread(ShowMenu);
            ThreadView.Start();
        }
    }
}
