using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Общий класс вывода строки таблицы рекордов
    /// </summary>
    public abstract class ViewHighscoreString
    {
        /// <summary>
        /// Позиция X вывода
        /// </summary>
        private int _x;
        /// <summary>
        /// Позиция Y вывода
        /// </summary>
        private int _y;
        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        private ModelHighcores _model;

        /// <summary>
        /// Позиция X вывода
        /// </summary>
        protected int X { get => _x; set => _x = value; }
        /// <summary>
        /// Позиция Y вывода
        /// </summary>
        protected int Y { get => _y; set => _y = value; }
        /// <summary>
        /// Модель таблицы рекордов
        /// </summary>
        protected ModelHighcores Model { get => _model; set => _model = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parX">Позиция X</param>
        /// <param name="parY">Позиция Y</param>
        public ViewHighscoreString(int parX, int parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Метод для вывода всей таблицы рекордов
        /// </summary>
        /// <param name="parHighscores">Список рекордов</param>
        public abstract void DrawAllItems(List<ModelHighscoreString> parHighscores);

        /// <summary>
        /// Метод для вывода одной строки таблицы рекордов
        /// </summary>
        /// <param name="parFirstColumn">Значение ячейки первого столбца</param>
        /// <param name="parSecondColumn">Значение ячейки второго столбца</param>
        /// <param name="parNum">Номер строки</param>
        public abstract void DrawItem(String parFirstColumn, String parSecondColumn, int parNum);
    }
}
