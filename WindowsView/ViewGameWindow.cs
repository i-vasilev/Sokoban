using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using Model;
using Model.Objects;
using System.Threading;
using WindowsView.Objects;
using WindowsView.Objects.Factories;
using View.Objects.Factories;

namespace WindowsView
{
    /// <summary>
    /// Класс вывода игры на windows форму
    /// </summary>
    public class ViewGameWindow : ViewGame
    {
        /// <summary>
        /// Время обновления(мс)
        /// </summary>
        private const int MILLISECONDS_TIMEOUT = 10;
        /// <summary>
        /// Форма вывода
        /// </summary>
        private Form _form;
        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;
        
        /// <summary>
        /// Ширина окна
        /// </summary>
        public const int WIDTH_WINDOW = 900;
        /// <summary>
        /// Высота окна
        /// </summary>
        public const int HEIGHT_WINDOW = 500;
        /// <summary>
        /// Размер игрового объекта
        /// </summary>
        public const int SIZE_GAME_OBJECT = 30;

        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public event DKeyDown KeyDown;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGameWindow(ModelGame parModelGame) : base(parModelGame)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                _form = new Form();
            }
            else
            {
                _form = Application.OpenForms[0];
            }
            var size = new Size(WIDTH_WINDOW, HEIGHT_WINDOW);
            _form.MaximumSize = size;
            _form.Size = size;
            _form.FormClosing += _form_FormClosing;
            _form.KeyDown += _form_KeyDown;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            ModelGame.ReadyToPlay += _modelGame_ReadyToPlay;
            ModelGame.GameWin += _modelGame_GameWin;
        }

        public override void StopGame()
        {
            base.StopGame();
            _form.FormClosing -= _form_FormClosing;
            _form.KeyDown -= _form_KeyDown;
        }

        /// <summary>
        /// Обработчик события победы
        /// </summary>
        private void _modelGame_GameWin()
        {
            StopGame();
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopGame();
        }

        /// <summary>
        /// Обработчик события готовности модели к выводу
        /// </summary>
        private void _modelGame_ReadyToPlay()
        {
            ThreadView = new Thread(ShowGame);
            ThreadView.Start();
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }


        /// <summary>
        /// Основной метод вывода игры на окно
        /// </summary>
        protected override void ShowGame()
        {
            int offsetX = (_form.Width - ModelGame.Field.Width * SIZE_GAME_OBJECT) / 2,
            offsetY = (_form.Height - ModelGame.Field.Height * SIZE_GAME_OBJECT) / 2;
            ViewGameObjectWindow viewHeroWindow = ViewBoxWindowFactory.CreateView(TypesView.ViewHero, offsetX, offsetY, _bufferedGraphics);
            ViewGameObjectWindow viewBoxWindow = ViewBoxWindowFactory.CreateView(TypesView.ViewBox, offsetX, offsetY, _bufferedGraphics);
            ViewGameObjectWindow viewPlaceBoxWindow = ViewBoxWindowFactory.CreateView(TypesView.ViewPlaceBox, offsetX, offsetY, _bufferedGraphics);
            ViewGameObjectWindow viewWallWindows = ViewBoxWindowFactory.CreateView(TypesView.ViewWall, offsetX, offsetY, _bufferedGraphics);
            ViewCounterMovesWindows viewCounterMoves = new ViewCounterMovesWindows(_bufferedGraphics, offsetX, offsetY);
            while (true)
            {
                lock (Locker)
                {
                    _bufferedGraphics.Graphics.Clear(Color.White);
                    viewWallWindows.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is Wall)));
                    viewPlaceBoxWindow.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is PlaceBox)));
                    viewBoxWindow.DrawAllObjects(ModelGame.Field.GameObjects.FindAll(new Predicate<GameObject>(a => a is Box)));
                    viewHeroWindow.Draw(ModelGame.Hero);
                    viewCounterMoves.Draw(ModelGame.CounterMoves);
                    _bufferedGraphics.Render();
                    Thread.Sleep(MILLISECONDS_TIMEOUT);
                }
            }
        }
    }
}
