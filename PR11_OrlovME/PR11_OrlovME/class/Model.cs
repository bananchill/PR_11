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

        public Pudge tank;
        public Wall walll;
        public gamestatus gamestatus;

        public Model(int sizeField, int amounttanks, int amountapples, int speedgame)
        {
            this.sizeField = sizeField; // передаем в поля переданные данные
            this.amounttanks = amounttanks;
            this.amountapples = amountapples;
            this.speedgame = speedgame;
            tank = new Pudge(sizeField);
            walll = new Wall();
        }
        public void play()
        {
            while (gamestatus == gamestatus.playing)
            {
                tank.run();
                Thread.Sleep(speedgame);
            }

        }

    }
}
