using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Objects
{
    /// <summary>
    /// Класс, представляющий описание игрового поля
    /// </summary>
    public class GameField
    {
        /// <summary>
        /// Объекты, присутствующие на игровом поле
        /// </summary>
        private List<GameObject> _gameObjects = new List<GameObject>();
        /// <summary>
        /// Словарь объектов для отображения
        /// </summary>
        private Dictionary<Type, List<GameObject>> _gameObjectsForView = new Dictionary<Type, List<GameObject>>();
        /// <summary>
        /// Ширина и высота игрового поля
        /// </summary>
        public int Width, Height;

        /// <summary>
        /// Объекты, присутствующие на игровом поле
        /// </summary>
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }
        /// <summary>
        /// Словарь объектов для отображения
        /// </summary>
        public Dictionary<Type, List<GameObject>> GameObjectsForView
        {
            get { return _gameObjectsForView; }
            set { _gameObjectsForView = value; }
        }
    }
}
