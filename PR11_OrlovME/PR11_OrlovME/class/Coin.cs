using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class Coin
    {
        CoinIMG coinimg = new CoinIMG();
        Image img;
        int x, y;
        public int X {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public Coin(int x,int y)
        {
            this.x = x;
            this.y = y;
            img = coinimg.ImgCoin;
        }
        public Image Img
        {
            get { return img; }
        }
    }
}
