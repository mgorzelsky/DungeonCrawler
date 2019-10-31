using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace DungeonCrawler
{
    class Enemy
    {
        static Random rnd = new Random();
        private Point position;
        public Point Position { get { return position; } }
        public Enemy()
        {
            StartingPosition();
        }
        private void StartingPosition()
        {
            position.X = rnd.Next(0, 8);
            position.Y = rnd.Next(0, 8);
        }

        public void Act(GameObjects[,] currentBoardState)
        {
            //find player
            //if player is adjacent call Attack()
            //if player is away call move in the direction of the player
        }

        private void Move(string direction)
        {
            switch (direction)
            {
                case ("up"):
                    if (position.Y > 0)
                        position.Y--;
                    break;
                case ("left"):
                    if (position.X > 0)
                        position.X--;
                    break;
                case ("down"):
                    if (position.Y < 7)
                        position.Y++;
                    break;
                case ("right"):
                    if (position.X < 7)
                        position.X++;
                    break;
            }
        }
        private void Attack()
        {
        }
    }
}
