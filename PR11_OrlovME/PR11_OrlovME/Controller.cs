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
using System.Media;

namespace PR11_OrlovME
{
    public partial class Controller_mainform : Form
    {


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
            model.changesteep += changerStatus;
            isSound = true;

            sound = new SoundPlayer(Properties.Resources.nurm);
        }


        void Controller_mainform_FormClosing(object sender, FormClosingEventArgs e)
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
        void StartPause_pictur(object sender, EventArgs e)
        {
            if (model.gamestatus == gamestatus.playing)
            {

                modelplay.Abort();
                model.gamestatus = gamestatus.stoping;
                pictureBox1.Image = Properties.Resources.play;
                changerStatus();
            }
            else
            {
                pictureBox1.Focus();
                modelplay = new Thread(model.play);
                modelplay.Start();
                model.gamestatus = gamestatus.playing;
                pictureBox1.Image = Properties.Resources.pause;
                view.Invalidate();
                changerStatus();
            }
        }
        void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    {
                        model.PAck.NextDirect_x = -1;
                        model.PAck.NextDirect_y = 0;
                    }
                    break;

                case "D":
                    {
                        model.PAck.NextDirect_x = 1;
                        model.PAck.NextDirect_y = 0;
                    }
                    break;

                case "W":
                    {
                        model.PAck.NextDirect_x = 0;
                        model.PAck.NextDirect_y = -1;
                    }
                    break;

                case "S":
                    {
                        model.PAck.NextDirect_x = 0;
                        model.PAck.NextDirect_y = 1;
                    }
                    break;
                case "Q":
                    {
                        setturnshot();
                    }
                    break;
            }
        }
        void setturnshot()
        {

            model.Projectile.Direct_x = model.PAck.Direct_x;
            model.Projectile.Direct_y = model.PAck.Direct_y;

            model.Projectile.X = model.PAck.X;
            model.Projectile.Y = model.PAck.Y;

            if (model.PAck.Direct_y == -1)
            {
                model.Projectile.X = model.PAck.X;
                model.Projectile.Y = model.PAck.Y + 10;

            }
            if (model.PAck.Direct_y == 1)
            {
                model.Projectile.X = model.PAck.X;
                model.Projectile.Y = model.PAck.Y + 10;
            }
            if (model.PAck.Direct_x == -1)
            {
                model.Projectile.X = model.PAck.X + 10;
                model.Projectile.Y = model.PAck.Y + 10;

            }
            if (model.PAck.Direct_x == 1)
            {
                model.Projectile.X = model.PAck.X + 10;
                model.Projectile.Y = model.PAck.Y;
            }
        }
        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            pictureBox1.Image = Properties.Resources.play;
            view.Refresh();
        }
        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"                               Танчики
        Управление клавишами - 'W', 'A', 'S', 'D' - ездить
                              'Q' - выстрел", "Танка");
        }
        void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
            soundToolStripMenuItem.Image = (isSound == true) ?
                 global::PR11_OrlovME.Properties.Resources.SoundOn
                : global::PR11_OrlovME.Properties.Resources.SoundOFF;
        }
        void changerStatus()
        {
            try
            {
                GameStatus_tool.Text = model.gamestatus.ToString();
                if (isSound)
                    if (model.gamestatus == gamestatus.playing)
                        sound.PlayLooping();
                    else
                        sound.Stop();
            }
            catch (Exception e) { MessageBox.Show("Вылетела непредвиденная ошибка"); }
        }

        View view;
        Model model;
        Thread modelplay;

        bool isSound;
        SoundPlayer sound;
    }
}

