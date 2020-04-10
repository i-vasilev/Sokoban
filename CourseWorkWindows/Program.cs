using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsController;

namespace CourseWorkWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerMainMenuWindows controller = ControllerMainMenuWindows.GetInstance();
            controller.Start();
        }
    }
}
