using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PR11_OrlovME
{
    class Wall : IPicture
    {
        WallImg WallImg = new WallImg();
        Image Imgwall;
        public Wall()
        {
            Imgwall = WallImg.ImgWall;
        }
        public Image Img
        {
            get { return Imgwall; }
        }
    }
}
