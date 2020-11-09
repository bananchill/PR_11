using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class FireTank
    {
        FiretankIMG fireTankIMG = new FiretankIMG();

        Image currentimg;
        Image[] img;
        int x, y;

        public Image Currentimg
        {
            get => currentimg;
        }
        public int X { get => x; }

        public int Y { get => y; }

        public FireTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            img = fireTankIMG.Imgup;
            PutCurrentImg();
        }
        public void Fire()
        {
            PutCurrentImg();
        }
        int k = 0;
        private void PutCurrentImg()
        {
            currentimg = img[k]; ;
            k++;
            if (k <= 4)
                k = 0;
        }
    }
}
