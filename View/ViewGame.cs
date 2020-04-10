using Model;
using Model.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace View
{
    /// <summary>
    /// Общий класс вывода игры на экран
    /// </summary>
    public abstract class ViewGame
    {
        /// <summary>
        /// Поток вывода
        /// </summary>
        private Thread _threadView;
        /// <summary>
        /// Модель игры
        /// </summary>
        private ModelGame _modelGame;

        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        private static object _locker = new object();

        /// <summary>
        /// Поток вывода
        /// </summary>
        protected Thread ThreadView { get => _threadView; set => _threadView = value; }
        /// <summary>
        /// Модель игры
        /// </summary>
        protected ModelGame ModelGame { get => _modelGame; set {
                _modelGame = value;
                _modelGame.GameWin += _modelGame_GameWin;
            }
        }
        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        protected static object Locker { get => _locker; set => _locker = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        /// <param name="parForm">Форма для вывода игры</param>
        public ViewGame(ModelGame parModelGame)
        {
            ModelGame = parModelGame;
        }

        /// <summary>
        /// Обработчик события победы в игре
        /// </summary>
        private void _modelGame_GameWin()
        {
            StopGame();
        }

        /// <summary>
        /// Останавливает поток вывода на форму.
        /// </summary>
        public virtual void StopGame()
        {
            ThreadView.Abort();
        }


        /// <summary>
        /// Основной метод вывода игры на окно
        /// </summary>
        protected abstract void ShowGame();
    }
}
