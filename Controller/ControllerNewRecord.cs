using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
    /// <summary>
    /// Класс контроллера нового рекорда
    /// </summary>
    public abstract class ControllerNewRecord
    {
        /// <summary>
        /// Поле view нового рекорда
        /// </summary>
        private ViewNewRecord _view;
        /// <summary>
        /// Поле модели новый рекорд
        /// </summary>
        private ModelHighscoreString _modelHighscoreString;
        /// <summary>
        /// Поле модели списка рекордов
        /// </summary>
        private ModelHighcores _modelHighscores;
        /// <summary>
        /// Поле новый ли рекорд
        /// </summary>
        private bool _isNewHighscore;

        /// <summary>
        /// view нового рекорда
        /// </summary>
        public ViewNewRecord View
        {
            get { return _view; }
            set { _view = value; }
        }
        /// <summary>
        /// Модель новый рекорд
        /// </summary>
        public ModelHighscoreString Model
        {
            get { return _modelHighscoreString; }
            set { _modelHighscoreString = value; }
        }
        /// <summary>
        /// Модель списка рекордов
        /// </summary>
        protected ModelHighcores ModelHighscores
        {
            get { return _modelHighscores; }
            set { _modelHighscores = value; }
        }
        /// <summary>
        /// Новый ли рекорд
        /// </summary>
        protected bool IsNewHighscore
        {
            get { return _isNewHighscore; }
            set { _isNewHighscore = value; }
        }

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public ControllerNewRecord(int parScore)
        {
            ModelHighscores = new Model.ModelHighcores();
            Model = new ModelHighscoreString() { Score = parScore };
        }

        /// <summary>
        /// Старт контроллера
        /// </summary>
        public abstract void Start();
    }
}
