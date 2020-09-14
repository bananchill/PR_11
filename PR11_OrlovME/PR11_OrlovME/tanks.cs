using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PR11_OrlovME
{
    class tanks
    {
        public Image img = Properties.Resources.ta;
        public int x, y;
        public void run()
        {
            x = ++y;
        }
    }
}
