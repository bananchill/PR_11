﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PR11_OrlovME
{
    class Pudge : IRun, ITurn, ITransp, ICurrentPicture, ITurnAround //, IPicture
    {
        protected int SizeField;
        protected int x, y, direct_x, direct_y;
        protected Image[] img;
        protected Image currentimg;

        PudgeImg pudgeImg = new PudgeImg();

        protected static Random r;
        protected int k = 0;
        private void PutImg()
        {

            if (Direct_x == 1)
                img = pudgeImg.Imgright;
            if (Direct_x == -1)
                img = pudgeImg.Imgup;
            if (Direct_y == 1)
                img = pudgeImg.ImgDown;
            if (Direct_y == -1)
                img = pudgeImg.Imgleft;
        }
        public Pudge(int sizefield, int x, int y)
        {
            this.SizeField = sizefield;
            img = pudgeImg.ImgDown;
            r = new Random();

            this.x = x;
            this.y = y;

            Direct_x = r.Next(-1, 2);
            if (Direct_x == 0)
            {
                Direct_y = 0;
                while (Direct_y == 0)
                    Direct_y = r.Next(-1, 2);
            }
            else
                Direct_y = 0;

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

        protected void PutCurrentImg()
        {
            currentimg = img[k];
            k++;
            if (k <= 4)
                k = 0;
        }

        public void Turn()
        {

            if (r.Next(5000) < 2500)  //по горизонтали
            {
                if (Direct_x == 0)
                {
                    Direct_y = 0;
                    while (Direct_x == 0)
                    {

                        Direct_x = r.Next(-1, 2);
                    }
                }
                else //по вертикали
                {
                    if (Direct_y == 0)
                    {
                        Direct_x = 0;
                        while (Direct_y == 0)
                        {
                            Direct_y = r.Next(-1, 2);
                        }
                    }
                }
                PutImg();
            }

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

        public void TurnArround()
        {
            // Разворот на 180 
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }

    }
}
