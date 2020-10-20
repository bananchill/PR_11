using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PR11_OrlovME
{
    class PudgeImg
    {
        Image img = Properties.Resources.trankDown;


        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
    }
}
