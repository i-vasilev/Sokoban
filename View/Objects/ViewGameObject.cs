using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace View.Objects
{
    /// <summary>
    /// Абстрактный класс вывода игрового обекта
    /// </summary>
    public abstract class ViewGameObject:ViewObject
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси Х</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        public ViewGameObject(int parOffsetX, int parOffsetY):base(parOffsetX, parOffsetY)
        {
        }

        /// <summary>
        /// Метод вывода одного объекта
        /// </summary>
        /// <param name="gameObject">Объект для вывода</param>
        public abstract void Draw(GameObject gameObject);

        /// <summary>
        /// Метод вывода списка объектов
        /// </summary>
        /// <param name="parGameObjects">Список объектов для вывода</param>
        public void DrawAllObjects(List<GameObject> parGameObjects)
        {
            foreach (var item in parGameObjects)
            {
                Draw(item);
            }
        }
    }
}
