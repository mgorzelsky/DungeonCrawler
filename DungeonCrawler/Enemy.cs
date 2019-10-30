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
        private List<Enemy> listOfEnemies = new List<Enemy>();
        public Enemy()
        {
            StartingPosition();
        }
        private void StartingPosition()
        {
            position.X = rnd.Next(0, 8);
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
