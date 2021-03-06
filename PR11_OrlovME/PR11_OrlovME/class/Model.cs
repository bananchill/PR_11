﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace PR11_OrlovME
{
    public delegate void STEEP();
    class Model
    {
        public int sizeField;
        int amounttanks;
        public int amountapples;

        int collectionsapple;

        public event STEEP changesteep;

        public int speedgame;

        List<Pudge> tanks;
        List<Coin> coins;
        List<FireTank> fires;
        Packman packman;

        Projectile projectile;

        public Model(int sizeField, int amounttanks, int amountapples, int speedgame)
        {
            this.sizeField = sizeField; // передаем в поля переданные данные
            this.amounttanks = amounttanks;
            r = new Random();
            this.speedgame = speedgame;
            this.amountapples = amountapples;
            collectionsapple = 0;

            tanks = new List<Pudge>();
            coins = new List<Coin>();
            fires = new List<FireTank>();
            projectile = new Projectile();
            CreateCoin();
            CreateTanks();

            walll = new Wall();
            packman = new Packman(sizeField);
        }

        public Wall walll;
        public gamestatus gamestatus;
        static Random r;

        internal List<Pudge> Tanks
        {
            get => tanks;
        }

        internal List<Coin> Coins
        {
            get => coins;
        }

        internal Packman PAck
        {
            get => packman;
        }

        internal Projectile Projectile
        {
            get => projectile;
        }

        internal List<FireTank> Fires
        { get => fires; }



        private void CreateCoin() //перегрузка
        {
            CreateCoin(0);
        }

        private void CreateCoin(int newapple)
        {
            int x, y;
            while (coins.Count < amountapples + newapple)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;

                bool flag = true;

                foreach (Coin a in coins)
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    coins.Add(new Coin(x, y));

            }
        }

        private void CreateTanks()
        {


            //// Задание начальных координат танка
            int x, y;
            while (tanks.Count < amounttanks + 1)
            {

                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, r.Next(6) * 40, r.Next(6) * 40));

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
                Thread.Sleep(speedgame);

                Runobject();
                DestroyTank();
                IfCollision();
                IfCollisionoftankandPack();
                IfPickApple();

                if (collectionsapple > amountapples - 1)
                {
                    gamestatus = gamestatus.winner;
                    if (changesteep != null)
                        changesteep();
                }

            }

        }

        private void Runobject()
        {
            ((Hunter)tanks[0]).Runn(packman.X, packman.Y);

            for (int i = 1; i < tanks.Count; i++)
                tanks[i].run();


            packman.run();
            projectile.Run();

            foreach (FireTank ft in fires)
                ft.Fire();

        }

        private void IfPickApple()
        {

            for (int i = 0; i < Coins.Count; i++)
            {
                if (Math.Abs(PAck.X - Coins[i].X) < 4 && Math.Abs(PAck.Y - Coins[i].Y) < 4)
                {
                    coins[i] = new Coin((collectionsapple) * 30, 280);
                    CreateCoin(++collectionsapple);


                }
            }

        }

        private void IfCollisionoftankandPack()
        {
            for (int i = 0; i < tanks.Count; i++)
                if (
                           ((Math.Abs(tanks[i].X - packman.X) <= 19) && (tanks[i].Y == packman.Y))
                       ||
                           ((Math.Abs(tanks[i].Y - packman.Y) <= 19) && (tanks[i].X == packman.X))
                       ||
                           ((Math.Abs(tanks[i].X - packman.X) <= 19) && (Math.Abs(tanks[i].Y - packman.Y) <= 19)))
                {

                    gamestatus = gamestatus.loozer;
                    if (changesteep != null)
                        changesteep();
                }
        }

        private void IfCollision()
        {
            for (int i = 0; i < tanks.Count - 1; i++)
                for (int j = i + 1; j < tanks.Count; j++)
                {
                    if (
                               ((Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (tanks[i].Y == tanks[j].Y))
                           ||
                               ((Math.Abs(tanks[i].Y - tanks[j].Y) <= 20) && (tanks[i].X == tanks[j].X))
                           ||
                               ((Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20))

                           )
                    {
                        if (i == 0)
                            ((Hunter)tanks[i]).TurnArround();
                        else
                            tanks[i].TurnArround();

                        tanks[j].TurnArround();

                    }
                }
        }

        private void DestroyTank()
        {
            for (int i = 1; i < tanks.Count; i++)
                if ((projectile.X - tanks[i].X) < 11 && (projectile.Y - tanks[i].Y) < 11
                    && (projectile.X - tanks[i].X) > 3 && (projectile.Y - tanks[i].Y) > 3)
                {
                    fires.Add(new FireTank(tanks[i].X, tanks[i].Y));
                    tanks.RemoveAt(i);
                    projectile.Default();

                }
        }

        internal void NewGame()
        {
            collectionsapple = 0;

            tanks = new List<Pudge>();
            coins = new List<Coin>();
            fires = new List<FireTank>();
            projectile = new Projectile();

            CreateCoin();
            CreateTanks();
            gamestatus = gamestatus.stoping;
            walll = new Wall();
            packman = new Packman(sizeField);
        }
    }
}


