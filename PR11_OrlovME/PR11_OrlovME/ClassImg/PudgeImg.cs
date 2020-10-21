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
        Image[] imgdown = new Image[] { Properties.Resources.tankdown,
            Properties.Resources.tankdown2,
        Properties.Resources.tankdown3,
        Properties.Resources.tankdown_4};
        Image[] imgup = new Image[] { Properties.Resources.tank1,
        Properties.Resources.tank2t,
        Properties.Resources.tank3,
        Properties.Resources.tank4};
        Image[] imgleft = new Image[] { Properties.Resources.tankleft,
        Properties.Resources.tankleft3,
        Properties.Resources.tankleft4,
        Properties.Resources.tanklef2};
        Image[] imgright = new Image[] { Properties.Resources.tankright,
         Properties.Resources.tankright2,
         Properties.Resources.tankright3,
         Properties.Resources.tankright4};


        public Image[] ImgDown
        {
            get { return imgright; }
            set { imgright = value; }
        }
        public Image[] Imgup
        {
            get { return imgup; }
            set { imgup = value; }
        }
        public Image[] Imgleft
        {
            get { return imgleft; }
            set { imgleft = value; }
        }
        public Image[] Imgright
        {
            get { return imgdown; }
            set { imgdown = value; }
        }   

    }
}
