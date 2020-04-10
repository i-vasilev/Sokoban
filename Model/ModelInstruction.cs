using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс для чтения и хранения текста инструкции к игре
    /// </summary>
    public class ModelInstruction
    { 

        /// <summary>
        /// Поле текста инструкции
        /// </summary>
        private String _textInstruction;

        /// <summary>
        /// Свойство текста инструкции
        /// </summary>
        public string TextInstruction { get => _textInstruction; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ModelInstruction()
        {
            _textInstruction = Resources.instruction;
        }
    }
}
