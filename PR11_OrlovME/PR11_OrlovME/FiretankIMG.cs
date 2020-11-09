﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR11_OrlovME
{
    class FiretankIMG
    {
        Image[] imglefgt = new Image[]{ Properties.Resources.fireleft };
        Image[] imgup = new Image[] { Properties.Resources.firetopt };
        Image[] imgright = new Image[] { Properties.Resources.fireright };
        Image[] imgdown = new Image[] { Properties.Resources.firedown };

        public Image[] Imgup
        {
            get => imgup;
        }
        public Image[] Imgdown
        { get => imgdown; }

        public Image[] Imgright
        {
            get => imgright; 
        }
        public Image[] Imgleft
        {
            get => imglefgt; 
        }
    }
}
