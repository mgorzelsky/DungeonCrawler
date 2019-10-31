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
        Player player;
        public Enemy(GameObjects[,] currentBoardState, Player player)
        {
            StartingPosition(currentBoardState);
            this.player = player;
        }
        private void StartingPosition(GameObjects[,] currentBoardState)
        {
            bool validPosition = false;
            while (!validPosition)
            {
                position.X = rnd.Next(0, 8);
                position.Y = rnd.Next(0, 8);
                if (currentBoardState[position.X, position.Y] == GameObjects.empty)
                    validPosition = true;
                else
                    validPosition = false;
            }
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
            player.TakeDamage();
        }
    }
}
