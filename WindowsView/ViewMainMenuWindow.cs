using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsView
{
    class ViewMainMenuWindow : View.ViewMainMenu
    {
        private Form _form;
        private BufferedGraphics _bufferedGraphics;

        public ViewMainMenuWindow()
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                var size = new Size(900, 500);
                _form = new Form();
                _form.MaximumSize = size;
                _form.Size = size;
            }
            else
            {
                _form = Application.OpenForms[0];
            }
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            Thread thread = new Thread(ShowMenu);
            thread.Start();
        }

        public override void ShowMenu()
        {
            while (true)
            {

            }
        }
    }
}
