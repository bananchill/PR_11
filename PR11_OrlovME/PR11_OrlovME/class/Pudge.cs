using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PR11_OrlovME
{
    class Pudge
    {
        
        int x, y;
        Image img;
        PudgeImg pudgeImg = new PudgeImg();
        public Pudge() {
            img = pudgeImg.Img;

        }
        public Image Img
        {
            get { return img; }

        }
        public int X
        {
            get { return x; }

        }
        public int Y
        {
            get { return y; }

        }
        public void run()
        {
            x = ++y;
        }
    }
}
