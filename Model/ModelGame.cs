using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model.Objects;

namespace Model
{
    /// <summary>
    /// Общая модель игры
    /// </summary>
    public class ModelGame
    {
        private const string PathToMapFile = "map.txt";

        /// <summary>
        /// Поле игры
        /// </summary>
        private GameField _field;
        /// <summary>
        /// Состояние героя
        /// </summary>
        private GameObject _hero;
        /// <summary>
        /// Счетчик перемещений
        /// </summary>
        private int _counterMoves;

        /// <summary>
        /// Делегат, позволяющий выдать событие при выигрыше
        /// </summary>
        public delegate void dEventHandler();
        /// <summary>
        /// Событие, возникающее при выигрыше
        /// </summary>
        public event dEventHandler GameWin;
        /// <summary>
        /// Событие, возникающее после чтения файла карты
        /// </summary>
        public event dEventHandler ReadyToPlay;

        /// <summary>
        /// Счетчик перемещений
        /// </summary>
        public int CounterMoves { get => _counterMoves; set => _counterMoves = value; }
        /// <summary>
        /// Поле игры
        /// </summary>
        public GameField Field { get => _field; set => _field = value; }
        /// <summary>
        /// Состояние героя
        /// </summary>
        public GameObject Hero { get => _hero; set => _hero = value; }
        

        /// <summary>
        /// Конструктор модели
        /// </summary>
        public ModelGame()
        {
            CounterMoves = 0;
        }

        /// <summary>
        /// Создаёт описание игрового поля
        /// </summary>
        /// <param name="parField">Текстовая карта игры</param>
        public void CreateGameField()
        {
            String[] lines = File.ReadAllLines(PathToMapFile);
            Field = new GameField
            {
                Width = 0,
                Height = lines.Length
            };
            List<GameObject> a = new List<GameObject>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > Field.Width)
                    Field.Width = lines[i].Length;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    Type type = null;
                    GameObject b = null;
                    switch (lines[i][j])
                    {
                        case '#':
                            b = new Box(j, i);
                            type = typeof(Box);
                            break;
                        case '*':
                            Hero = new Hero(j, i);
                            break;
                        case '+':
                            b = new Wall(j, i);
                            type = typeof(Wall);
                            break;
                        case '.':
                            b = new PlaceBox(j, i);
                            type = typeof(PlaceBox);
                            break;
                        default:
                            continue;
                    }
                    if (b != null && type != null)
                    {
                        Field.GameObjects.Add(b);
                        if (Field.GameObjectsForView.TryGetValue(type, out a))
                        {
                            Field.GameObjectsForView[type].Add(b);
                        }
                        else
                        {
                            Field.GameObjectsForView.Add(type, new List<GameObject>() { b });
                        }
                    }
                }
            }
            ReadyToPlay?.Invoke();
        }

        /// <summary>
        /// Делает ход игроком в направлении, указанном в direction
        /// </summary>
        /// <param name="parDirection">Направление хода</param>
        public void MoveHero(String parDirection)
        {
            if (parDirection != null)
            {
                parDirection = parDirection.ToLower();
                bool movingPossibility = CheckMovingPossibility(Hero, parDirection, false);
                if (movingPossibility)
                {
                    switch (parDirection)
                    {
                        case "up":
                            GameObject gameObject = GetObjectByItsCoords(Hero.X, Hero.Y - 1);
                            if (gameObject != null)
                            {
                                if (CheckMovingPossibility(gameObject, parDirection, true))
                                {
                                    gameObject.Y--;
                                }
                                else
                                {
                                    movingPossibility = false;
                                }
                            }
                            if (movingPossibility)
                            {
                                Hero.Y--;
                                CounterMoves++;
                            }
                            break;
                        case "down":
                            gameObject = GetObjectByItsCoords(Hero.X, Hero.Y + 1);
                            if (gameObject != null)
                            {
                                if (CheckMovingPossibility(gameObject, parDirection, true))
                                {
                                    gameObject.Y++;
                                }
                                else
                                {
                                    movingPossibility = false;
                                }
                            }
                            if (movingPossibility)
                            {
                                Hero.Y++;
                                CounterMoves++;
                            }
                            break;
                        case "right":
                            gameObject = GetObjectByItsCoords(Hero.X + 1, Hero.Y);
                            if (gameObject != null)
                            {
                                if (CheckMovingPossibility(gameObject, parDirection, true))
                                {
                                    gameObject.X++;
                                }
                                else
                                {
                                    movingPossibility = false;
                                }
                            }
                            if (movingPossibility)
                            {
                                Hero.X++;
                                CounterMoves++;
                            }
                            break;
                        case "left":
                            gameObject = GetObjectByItsCoords(Hero.X - 1, Hero.Y);
                            if (gameObject != null)
                            {
                                if (CheckMovingPossibility(gameObject, parDirection, true))
                                {
                                    gameObject.X--;
                                }
                                else
                                {
                                    movingPossibility = false;
                                }
                            }
                            if (movingPossibility)
                            {
                                Hero.X--;
                                CounterMoves++;
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (CheckForWin())
                    GameWin?.Invoke();
            }
        }

        /// <summary>
        /// Проверка возможности перемещения
        /// </summary>
        /// <param name="parGameObject">Объект</param>
        /// <param name="parDirection">Направление</param>
        /// <param name="parCheckBoxes">Проверять ли коробки</param>
        /// <returns>Возможность перемещения</returns>
        private bool CheckMovingPossibility(GameObject parGameObject, String parDirection, bool parCheckBoxes)
        {
            foreach (var item in Field.GameObjects)
            {
                switch (parDirection)
                {
                    case "up":
                        if (item.Y == parGameObject.Y - 1 && item.X == parGameObject.X && (item is Wall || (parCheckBoxes && item is Box)))
                        {
                            return false;
                        }
                        break;
                    case "down":
                        if (item.Y == parGameObject.Y + 1 && item.X == parGameObject.X && (item is Wall || (parCheckBoxes && item is Box)))
                        {
                            return false;
                        }
                        break;
                    case "right":
                        if (item.Y == parGameObject.Y && item.X == parGameObject.X + 1 && (item is Wall || (parCheckBoxes && item is Box)))
                        {
                            return false;
                        }
                        break;
                    case "left":
                        if (item.Y == parGameObject.Y && item.X == parGameObject.X - 1 && (item is Wall || (parCheckBoxes && item is Box)))
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// Получить объект по его координатам
        /// </summary>
        /// <param name="parX">X координата</param>
        /// <param name="parY">Y координата</param>
        /// <returns>Объект или null находящийся на координате</returns>
        private GameObject GetObjectByItsCoords(int parX, int parY)
        {
            foreach (var item in Field.GameObjects)
            {
                if (item.X == parX && item.Y == parY && item is Box)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Проверка победы
        /// </summary>
        /// <returns>Победил ли игрок</returns>
        private bool CheckForWin()
        {
            bool result = true;
            List<GameObject> boxes = Field.GameObjectsForView[typeof(Box)];
            List<GameObject> placeBoxes = Field.GameObjectsForView[typeof(PlaceBox)];
            foreach (var box in boxes)
            {
                bool isHas = false;
                foreach (var placeBox in placeBoxes)
                {
                    if (box.X == placeBox.X && box.Y == placeBox.Y)
                    {
                        isHas = true;
                    }
                }
                if (!isHas)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
