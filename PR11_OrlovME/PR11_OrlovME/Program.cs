using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR11_OrlovME
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            Controller_mainform cf;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (arg.Length)
            {
                case 0:
                    cf = new Controller_mainform();
                    break;
                case 1:
                    cf = new Controller_mainform(Convert.ToInt32(arg[0]));
                    break;
                case 2:
                    cf = new Controller_mainform(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]));
                    break;
                case 3:
                    cf = new Controller_mainform(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2]));
                    break;
                case 4:
                    cf = new Controller_mainform(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2]), Convert.ToInt32(arg[3]));
                    break;
                default:
                    cf = new Controller_mainform();
                    break;


            }

            Application.Run(cf);
        }
    }
}
