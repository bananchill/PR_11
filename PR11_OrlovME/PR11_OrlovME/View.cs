using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PR11_OrlovME
{
    partial class View : UserControl
    {
        Model model;
        public View(Model model)
        {
            InitializeComponent();
            this.model = model;

        }



        void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.wall.Img, new Point(20, 20));
            e.Graphics.DrawImage(model.tank.Img, new Point(model.tank.X, model.tank.Y));
            if (model.gamestatus != gamestatus.playing)
                return;
            
            Thread.Sleep(model.speedgame);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
