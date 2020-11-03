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
            for (int y = 20; y < 260; y += 40)
                for (int x = 20; x < 260; x += 40)
                    e.Graphics.DrawImage(model.walll.Img, new Point(x, y));
        }

        public void DrawPudge(PaintEventArgs e)
        {
            foreach (Pudge t in model.Tanks)
            e.Graphics.DrawImage(t.CurrentImg, new Point(t.X, t.Y));
        }
        public void DrawCoin(PaintEventArgs e)
        {
            foreach (Coin t in model.Coins)
                e.Graphics.DrawImage(t.Img, new Point(t.X, t.Y));
        }
        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawCoin(e);
            DrawPudge(e);
            DrawPack(e);
            
             if (model.gamestatus != gamestatus.playing)
                return;

            Thread.Sleep(model.speedgame);
            Invalidate();
        }

        private void DrawPack(PaintEventArgs e)
        {
           
                e.Graphics.DrawImage(model.PAck.CurrentImg, new Point(model.PAck.X, model.PAck.Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
