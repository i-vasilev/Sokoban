using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace WindowsView
{
    class ViewMenuItemWindow : ViewMenuItem
    {
        private BufferedGraphics _bufferedGraphics;
        public ViewMenuItemWindow(BufferedGraphics parBufferedGraphics)
        {
            _bufferedGraphics = parBufferedGraphics;
        }

        public override void Draw(int parX, int parY)
        {

        }
    }
}
