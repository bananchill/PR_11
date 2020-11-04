using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PR11_OrlovME
{
    class Packman : IRun, ITurn, ITransp, ICurrentPicture
    {
        int SizeField;
        int x, y, direct_x, direct_y, nextDirect_x, nextDirect_y;
        Image[] img;
        Image currentimg;

        PackIMG packImg = new PackIMG();

        public Packman(int sizefield)
        {
            this.SizeField = sizefield;
            img = packImg.ImgDown;

            this.x = 120;
            this.y = 240;

            nextDirect_x = -1;
            nextDirect_y = 0;

            PutImg();
            PutCurrentImg();
        }

        public Image CurrentImg
        {
            get { return currentimg; }
        }
        public Image[] Img
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
        public int Direct_x
        {
            get { return direct_y; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    direct_y = value;
                else
                    direct_y = 0;

            }
        }
        public int NextDirect_x
        {
            get { return nextDirect_x; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    nextDirect_y = value;
                else
                    nextDirect_y = 0;

            }
        }
        public int NextDirect_y
        {
            get { return nextDirect_y; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    nextDirect_x = value;
                else
                    nextDirect_x = 0;

            }
        }
        public int Direct_y
        {
            get { return direct_x; }
            set
            {
                if (value == 0 || value == 1 || value == -1)
                    direct_x = value;
                else
                    direct_x = 0;

            }
        }



        public void run()
        {
            y += Direct_x;
            x += Direct_y;
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
            {
                Turn();

            }
            PutCurrentImg();
            Transparent();

        }

        int k = 0;
        private void PutCurrentImg()
        {
            currentimg = img[k];
            k++;
            if (k <= 4)
                k = 0;
        }

        public void Turn()
        {
            Direct_x = NextDirect_x;
            Direct_y = NextDirect_y;

            PutImg();


        }



        public void Transparent()
        {

            if (x == -1) // выход за левое поле
                x = SizeField - 21;
            if (x == SizeField - 19) // выход за правое поле
                x = 1;

            if (y == -1) // выход за верхнее поле
                y = SizeField - 21;
            if (y == SizeField - 19) // выход за нижнее поле
                y = 1;


        }
        public void PutImg()
        {

            if (Direct_x == 1)
                img = packImg.Imgright;
            if (Direct_x == -1)
                img = packImg.Imgup;
            if (Direct_y == 1)
                img = packImg.ImgDown;
            if (Direct_y == -1)
                img = packImg.Imgleft;
        }
        public void TurnArround()
        {
            // Разворот на 180 
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }

    }
}
