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
        int amounttanks;
        public int amountapples;
        public int speedgame;

        List<Pudge> tanks;
        List<Coin> coins;
        Packman packman;

      



        public Wall walll;
        public gamestatus gamestatus;

        static Random r;

        internal List<Pudge> Tanks
        {
            get { return tanks; }

        }
        internal List<Coin> Coins
        {
            get { return coins; }

        }
        internal Packman PAck
        {
            get { return packman; }

        }
        public Model(int sizeField, int amounttanks, int amountapples, int speedgame)
        {
            this.sizeField = sizeField; // передаем в поля переданные данные
            this.amounttanks = amounttanks;
            r = new Random();
            this.amountapples = amountapples;
            this.speedgame = speedgame;
            tanks = new List<Pudge>();
            coins = new List<Coin>();
            CreateCoin();
            CreateTanks();

            walll = new Wall();
            packman = new Packman(sizeField);
        }

        private void CreateCoin()
        {
            int x, y;
            while (coins.Count < amountapples)
            {
                x = r.Next(7) * 40;
                y = r.Next(7) * 40;

                bool flag = true;

                foreach (Coin a in coins)
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    coins.Add(new Coin( x, y));

            }
        }

        private void CreateTanks()
        {
            //// Задание начальных координат танка
            int x, y;
            while (tanks.Count < amounttanks)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;

                bool flag = true;

                foreach (Pudge t in tanks)
                    if (t.X == x && t.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    tanks.Add(new Pudge(sizeField, x, y));

            }
        }

        public void play()
        {
            while (gamestatus == gamestatus.playing)
            {
                foreach (Pudge t in tanks)
                    t.run();
                packman.run();
                for (int i = 0; i < tanks.Count - 1; i++)
                    for (int j = i + 1; j < tanks.Count; j++)
                        if (
                                 ((Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (tanks[i].Y == tanks[j].Y))
                             ||
                                 ((Math.Abs(tanks[i].Y - tanks[j].Y) <= 20) && (tanks[i].X == tanks[j].X))
                             ||
                                 ((Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20)))
                        {
                            tanks[i].TurnArround();
                            tanks[j].TurnArround();
                        }

                Thread.Sleep(speedgame);
            }

        }

    }
}

