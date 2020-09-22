using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PR11_OrlovME
{
    class Pudge : IRun, ITurn, ITransp
    {
        int SizeField;
        int x, y, direct_x, direct_y;
        Image img;
        PudgeImg pudgeImg = new PudgeImg();
        static Random r;


        public Pudge(int sizefield)
        {
            this.SizeField = sizefield;
            img = pudgeImg.Img;
            r = new Random();
            x = 80;
            y = 80;
            Direct_y = 0;
            Direct_x = 1;

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
                Transparent();
            }
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


            }
        }

        public void Transparent()
        {

            if (x == -1)
                x = SizeField - 21;
            if (x == SizeField - 19)
                x = 1;
            if (y == -1)
                y = SizeField - 21;
            if (y == SizeField - 19)
                y = 1;


        }



    }
}
