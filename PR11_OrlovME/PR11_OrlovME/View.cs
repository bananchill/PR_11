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


        void DrawWall(PaintEventArgs e)
        {
            for(int y=20; y< 260; y+=40)
                for (int x = 20; x < 260; x +=40 )
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
        }

        void DrawPudge(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.tank.Img, new Point(model.tank.X, model.tank.Y));
        }

        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawPudge(e);
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
