using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Модель пункта меню
    /// </summary>
    public class ModelMenuItem
    {
        /// <summary>
        /// Делегат действия привязанного к пункту меню
        /// </summary>
        public delegate void DDoAction();
        /// <summary>
        /// Действие, привязанное к пункту меню
        /// </summary>
        public DDoAction Action;

        /// <summary>
        /// Текст пункта меню
        /// </summary>
        private string _text;
        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string Text { get { return _text; } set { _text = value; } }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parText">Текст пункта меню</param>
        /// <param name="parDoAction">Действие, привязанное к пункту меню</param>
        public ModelMenuItem(string parText, DDoAction parDoAction)
        {
            _text = parText;
            Action = parDoAction;
        }
    }
}
