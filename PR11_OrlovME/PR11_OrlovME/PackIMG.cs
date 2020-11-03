using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class PackIMG
    {
        Image[] imgup = new Image[] { Properties.Resources.Packdown2,
            Properties.Resources.Packdown3,
        Properties.Resources.Packdown4};
        Image[] imgdown = new Image[] { Properties.Resources.Packup,
        Properties.Resources.Packup2,
        Properties.Resources.Packup3};
        Image[] imgright = new Image[] { Properties.Resources.Packleft,
        Properties.Resources.Packleft2,
        Properties.Resources.Packleft3,
        Properties.Resources.Packleft4};
        Image[] imgleft = new Image[] { Properties.Resources.Packright,
         Properties.Resources.Packright2,
         Properties.Resources.Packright3,
         Properties.Resources.Packright4};


        public Image[] ImgDown
        {
            get { return imgright; }
        }
        public Image[] Imgup
        {
            get { return imgup; }
        }
        public Image[] Imgleft
        {
            get { return imgleft; }
        }
        public Image[] Imgright
        {
            get { return imgdown; }
        }
    }
}
