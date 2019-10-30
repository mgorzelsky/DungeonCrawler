using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DungeonCrawler
{
    class Enemy
    {
        private Point position;
        public Point Position { get { return position; } }
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
