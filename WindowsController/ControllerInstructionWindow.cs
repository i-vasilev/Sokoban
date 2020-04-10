using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsView;
using static Model.ModelGame;

namespace WindowsController
{
    /// <summary>
    /// Контроллер формы инструкции
    /// </summary>
    class ControllerInstructionWindow : ControllerInstruction
    {
        /// <summary>
        /// Событие, вызывающееся при закрытии инструкции
        /// </summary>
        public event dEventHandler Close;

        /// <summary>
        /// Старт формы инструкции
        /// </summary>
        public override void Start()
        {
            Model = new ModelInstruction();
            View = new ViewInstructionWindows(Model);
            ((ViewInstructionWindows)View).KeyDown += ControllerInstructionWindow_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerInstructionWindow_KeyDown(System.Windows.Forms.KeyEventArgs parE)
        {
            switch (parE.KeyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    ((ViewInstructionWindows)View).StopView();
                    Close?.Invoke();
                    break;
            }
        }
    }
}
