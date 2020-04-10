using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace ConsoleView
{
    /// <summary>
    /// Класс для вывода строк таблицы рекордов
    /// </summary>
    public class ViewHighscoreStringConsole : ViewHighscoreString
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Начальная позиция X</param>
        /// <param name="parY">Начальная позиция Y</param>
        public ViewHighscoreStringConsole(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Выводит все строки таблицы рекордов в консоль
        /// </summary>
        /// <param name="parHighscores">Строки таблицы рекордов</param>
        public override void DrawAllItems(List<ModelHighscoreString> parHighscores)
        {
            int num = 0;
            DrawItem("Игрок", "Ходов", num++);
            foreach (var item in parHighscores)
            {
                DrawItem(item.Name, item.Score.ToString(), num++);
            }
        }

        /// <summary>
        /// Выводит строку таблицы рекордов в консоль
        /// </summary>
        /// <param name="parFirstColumn">Значение ячейки первого столбца таблицы рекордов</param>
        /// <param name="parSecondColumn">Значение ячейки второго столбца таблицы рекордов<</param>
        /// <param name="parNum">Номер строки</param>
        public override void DrawItem(String parFirstColumn, String parSecondColumn, int parNum)
        {
            FastOutput.Write(parFirstColumn, X, Y + parNum * 2, ConsoleColor.White);
            FastOutput.Write(parSecondColumn, X + 20, Y + parNum * 2, ConsoleColor.White);
        }
    }
}
