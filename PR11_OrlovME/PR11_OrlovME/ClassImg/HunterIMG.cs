using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class HunterIMG
    {
        Image[] imgup = new Image[] { Properties.Resources.Hunterdown,
            Properties.Resources.Hunterdown2,
        Properties.Resources.Hunterdown3};
        Image[] imgdown = new Image[] { Properties.Resources.Hunterup,
        Properties.Resources.Hunterup2,
        Properties.Resources.Hunterup3};
        Image[] imgright = new Image[] { Properties.Resources.Hunterleft,
        Properties.Resources.Hunterleft2,
        Properties.Resources.Hunterleft3,
        Properties.Resources.Hunterleft4};
        Image[] imgleft = new Image[] { Properties.Resources.Hunterright,
         Properties.Resources.Hunterright2,
         Properties.Resources.Hunterright3};


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
