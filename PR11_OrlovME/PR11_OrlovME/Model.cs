using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace PR11_OrlovME
{
    class Model
    {
        public int sizeField;
        public int amounttanks;
        public int amountapples;
        public int speedgame;

        public tanks tank;

        public Model(int sizeField, int amounttanks, int amountapples, int speedgame)
        {
            this.sizeField = sizeField; // передаем в поля переданные данные
            this.amounttanks = amounttanks;
            this.amountapples = amountapples;
            this.speedgame = speedgame;
            tank = new tanks();
        }
        public void play()
        {
            while (true)
            {
                tank.run();
                Thread.Sleep(speedgame);
            }

        }

    }
}
