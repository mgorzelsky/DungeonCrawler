using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DungeonCrawler
{
    class Player
    {
        private Point position;
        public Point Position { get { return position; } }
        public Player()
        {
            ResetPosition();
        }

        //Player always starts in the bottom left corner
        private void ResetPosition()
        {
            position.X = 0;
            position.Y = 7;
        }
        public void HandleInput(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow
                || keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
                Move(keyPressed);
            if (keyPressed == ConsoleKey.Spacebar)
                Attack();
        }
        private void Move(ConsoleKey direction)
        {
            switch (direction)
            {
                case (ConsoleKey.UpArrow):
                    position.Y--;
                    break;
                case (ConsoleKey.LeftArrow):
                    position.X--;
                    break;
                case (ConsoleKey.DownArrow):
                    position.Y++;
                    break;
                case (ConsoleKey.RightArrow):
                    position.X++;
                    break;
            }
        }
        private void Attack()
        {
            Console.WriteLine("ATTACK!");
        }
    }
}
