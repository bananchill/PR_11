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

        HunterIMG pudgeImg = new HunterIMG();

        public Hunter(int sizefield, int x, int y) : base(sizefield, x, y) { }
        
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

        new public void Turn(int x, int y)
        {


        }

        new public void Runn(int x, int y)
        {

            target_x = x;
            target_y = y;
            y += Direct_x;
            x += Direct_y;
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
            {
                Turn();

            }
            PutCurrentImg();
            Transparent();

        }
    }

}
