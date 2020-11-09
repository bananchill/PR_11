using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class Hunter : Pudge
    {

        int target_x, target_y;

        HunterIMG hunterimg = new HunterIMG();


        private void PutImg()
        {

            if (Direct_x == 1)
                img = hunterimg.Imgright;
            if (Direct_x == -1)
                img = hunterimg.Imgup;
            if (Direct_y == 1)
                img = hunterimg.ImgDown;
            if (Direct_y == -1)
                img = hunterimg.Imgleft;
        }



        new public void TurnArround()
        {
            // Разворот на 180 
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }

        public void Turn(int target_x, int target_y)
        {
            Direct_y = Direct_x = 0;
            if (X > target_x)
                Direct_x = -1;
            if (X < target_x)
                Direct_x = 1;
            if (Y > target_y)
                Direct_y = -1;
            if (Y < target_y)
                Direct_y = 1;

            if (Direct_x != 0 && Direct_y != 0)
                if (r.Next(5000) < 2500)
                    Direct_x = 0;
                else
                    Direct_y = 0;
            PutImg();
        }

        public void Runn(int target_x, int target_y)
        {

            x += Direct_x;
            y += Direct_y;

            if (Math.IEEERemainder(x, 40) == 0 && (Math.IEEERemainder(y, 40) == 0))
            {
                Turn(target_x, target_y);
            }
            PutCurrentImg();
            Transparent();

        }

        public Hunter(int sizefield, int x, int y) 
            : base(sizefield, x, y)
        {
            Direct_y = -1;
            Direct_x = 0;
            PutImg();
            PutCurrentImg();
        }
    }

}
