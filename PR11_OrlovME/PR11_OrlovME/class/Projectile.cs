using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class Projectile
    {
        private ProjectileIMG projectileIMG = new ProjectileIMG();

        int x, y, direct_x, direct_y;

        private Image img;
        public Image Img { get => img; }


        public Projectile()
        {
            img = projectileIMG.Imgup;
            Default();
        }

        public void Default()
        {
            x = y = -10;
            Direct_x = Direct_y = 0;
            km = 0;
        }

        public int X { get => x; set => x = value; }

        public int Y { get => y; set => y = value; }

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



        private void PutImg()
        {

            if (direct_x == 1)
                img = projectileIMG.Imgright;
            if (direct_x == -1)
                img = projectileIMG.Imgleft;
            if (direct_y == 1)
                img = projectileIMG.Imgdown;
            if (direct_y == -1)
                img = projectileIMG.Imgup;

        }
        int km;
        public void Run()
        {
            if (Direct_x == 0 && Direct_y == 0)
                return;
            km++;
            PutImg();
            x += direct_x * 3;
            y += direct_y * 3;
            if (km * 2 > 100)
                Default();

        }
    }
}
