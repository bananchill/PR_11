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

            view = new View(model);
            this.Controls.Add(view);


        }

        private void myform_Load(object sender, EventArgs e)
        {

        }

        private void StartstopButton_Click(object sender, EventArgs e)
        {
            modelplay = new Thread(model.play);
            modelplay.Start();

        }
    }
}
