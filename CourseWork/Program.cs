using ConsoleController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerMainMenuConsole controller = ControllerMainMenuConsole.GetInstance();
            controller.Start();
        }
    }
}
