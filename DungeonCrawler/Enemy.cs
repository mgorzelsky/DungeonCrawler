using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace DungeonCrawler
{
    class Enemy
    {
        Random rnd = new Random();
        private Point position;
        public Point Position { get { return position; } }
        public Enemy()
        {
            StartingPosition();
        }
        private void StartingPosition()
        {
            position.X = rnd.Next(0, 8);
            Thread.Sleep(16); //Random.Next() has a resolution of about 15ms. If you don't wait that long then the number it generates will be the same as the previous.
            position.Y = rnd.Next(0, 8);
        }
        private void Move(string direction)
        {
            switch (direction)
            {
                case ("up"):
                    position.Y--;
                    break;
                case ("left"):
                    position.X--;
                    break;
                case ("down"):
                    position.Y++;
                    break;
                case ("right"):
                    position.X++;
                    break;
            }
        }
        private void Attack()
        {
        }
    }
}
