using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PR11_OrlovME
{
    class WallImg
    {
        Image imgwall = Properties.Resources.wall;


        public Image ImgWall
        {
            get { return imgwall; }
            set { imgwall = value; }
        }
    }
}
