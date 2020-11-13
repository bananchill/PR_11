using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class ProjectileIMG
    {
        Image imglefgt = Properties.Resources.Cartridge;
        Image imgup = Properties.Resources.Cartridgetop;
        Image imgright = Properties.Resources.Cartridgeright;
        Image imgdown = Properties.Resources.Cartridgedown;

        public Image Imgup
        {
            get { return imgup; }
        }
        public Image Imgdown
        {
            get { return imgdown; }
        }
        public Image Imgright
        {
            get { return imgright; }
        }
        public Image Imgleft
        {
            get { return imglefgt; }
        }
    }
}
