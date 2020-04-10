using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Класс для вывода таблицы рекордов на консоль
    /// </summary>
    public class ViewHighscoreConsole : ViewHighscores
    {
       /// <summary>
       /// Конструктор класса
       /// </summary>
       /// <param name="parModel">Модель таблицы рекордов</param>
        public ViewHighscoreConsole(ModelHighcores parModel) : base(parModel)
        {
            Model = parModel;
            ThreadView = new Thread(ShowHighscores);
            ThreadView.Start();
        }

        /// <summary>
        /// Вывод таблицы на экран
        /// </summary>
        public override void ShowHighscores()
        {
            ViewHighscoreStringConsole view = new ViewHighscoreStringConsole(30, 1);
            while (true)
            {
                FastOutput.Clear();
                view.DrawAllItems(Model.Highscores);
                FastOutput.PrintOnConsole();
            }
        }

        /// <summary>
        /// Останавливает поток вывода на экран
        /// </summary>
        public override void StopView()
        {
            ThreadView.Abort();
        }
    }
}
