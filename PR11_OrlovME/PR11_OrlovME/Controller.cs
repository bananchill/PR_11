using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PR11_OrlovME
{
    public partial class Controller_mainform : Form
    {
        View view;
        Model model;
        Thread modelplay;

        public Controller_mainform() : this(260) { }
        public Controller_mainform(int sizeField) : this(sizeField, 5) { }
        public Controller_mainform(int sizeField, int amounttanks) : this(sizeField, amounttanks, 5) { }
        public Controller_mainform(int sizeField, int amounttanks, int amountapples) : this(sizeField, amounttanks, amountapples, 50) { }
        public Controller_mainform(int sizeField, int amounttanks, int amountapples, int speedgame)
        {
            InitializeComponent();
            model = new Model(sizeField, amounttanks, amountapples, speedgame);
            model.gamestatus = gamestatus.stoping;
            view = new View(model);
            this.Controls.Add(view);


        }

        private void myform_Load(object sender, EventArgs e)
        {

        }

        private void StartstopButton_Click(object sender, EventArgs e)
        {
            if (model.gamestatus == gamestatus.playing)
            {
                modelplay.Abort();
                model.gamestatus = gamestatus.stoping;
            }
            else
            {
                modelplay = new Thread(model.play);
                modelplay.Start();
                model.gamestatus = gamestatus.playing;
                view.Invalidate();
            }

        }

        private void Controller_mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelplay != null)
            {

                modelplay.Abort();
                model.gamestatus = gamestatus.stoping;
            }
            DialogResult dr = MessageBox.Show("Вы уверены , что хотите закончить игру", "Танчики - Орлов М Е", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void Controller_mainform_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                case 'ф':
                case 'A':
                case 'Ф':
                    {
                        model.PAck.NextDirect_x = -1;
                        model.PAck.NextDirect_y = 0;
                    }
                    break;
                case 'd':
                case 'в':
                case 'D':
                case 'В':
                    {
                        model.PAck.NextDirect_x = 1;
                        model.PAck.NextDirect_y = 0;
                    }
                    break;
                case 'w':
                case 'ц':
                case 'W':
                case 'Ц':
                    {
                        model.PAck.NextDirect_x = 0;
                        model.PAck.NextDirect_y = -1;
                    }
                    break;
                case 's':
                case 'ы':
                case 'S':
                case 'Ы':
                    {
                        model.PAck.NextDirect_x = 0;
                        model.PAck.NextDirect_y = 1;
                    }
                    break;
                default:
                    //{

                    //    model.Projectile.Direct_x = model.PAck.Direct_x;
                    //    model.Projectile.Direct_y = model.PAck.Direct_y;

                    //    model.Projectile.X = model.PAck.X;
                    //    model.Projectile.Y = model.PAck.Y;

                    //    if (model.Sonic.Direct_y == -1)
                    //    {
                    //        model.Projectile.X = model.PAck.X + 2;
                    //        model.Projectile.Y = model.PAck.Y;

                    //    }
                    //    if (model.Sonic.Direct_y == 1)
                    //    {
                    //        model.Projectile.X = model.PAck.X + 2;
                    //        model.Projectile.Y = model.PAck.Y;
                    //    }
                    //if (model.Sonic.Direct_x == -1)
                    //{
                    //    model.Projectile.X = model.Sonic.X;
                    //    model.Projectile.Y = model.Sonic.Y + 10;
                    //}
                    //if (model.Sonic.Direct_x == 1)
                    //{
                    //    model.Projectile.X = model.Sonic.X + 20;
                    //    model.Projectile.Y = model.Sonic.Y + 10;
                    //}

                    //}
                    break;
            }
        }

        private void StartstopButton_Leave(object sender, EventArgs e)
        {
            StartstopButton.Focus();
        }
    }
}
