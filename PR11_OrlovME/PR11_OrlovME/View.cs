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
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].CurrentImg, new Point(model.Tanks[i].X, model.Tanks[i].Y));
        }
        public void DrawCoin(PaintEventArgs e)
        {
            for (int i = 0; i < model.Coins.Count; i++)
                e.Graphics.DrawImage(model.Coins[i].Img, new Point(model.Coins[i].X, model.Coins[i].Y));
        }
        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawFireT(e);
            DrawCoin(e);
            DrawPudge(e);
            DrawPack(e);
            DrawProjectile(e);


            if (model.gamestatus != gamestatus.playing)
                return;

            Thread.Sleep(model.speedgame);
            Invalidate();
        }

        private void DrawFireT(PaintEventArgs e)
        {

            foreach (FireTank ft in model.Fires)
                e.Graphics.DrawImage(ft.Currentimg, new Point(ft.X, ft.Y));
        }

        public void DrawProjectile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Projectile.Img, new Point(model.Projectile.X, model.Projectile.Y));
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
