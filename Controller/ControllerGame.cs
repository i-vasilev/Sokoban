using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using View;

namespace Controller
{
    /// <summary>
    /// Общий контроллер игры
    /// </summary>
    public abstract class ControllerGame
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        public ModelGame ModelGame;
        /// <summary>
        /// объект view игры
        /// </summary>
        public ViewGame ViewGame;

        /// <summary>
        /// Старт игры
        /// </summary>
        public virtual void Start()
        {
            ModelGame.CreateGameField();
        }

    }
}
