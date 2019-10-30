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
        public bool HandleInput(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow
                || keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
                return Move(keyPressed);
            if (keyPressed == ConsoleKey.Spacebar)
                Attack();
        }
        private bool Move(ConsoleKey direction)
        {
            switch (direction)
            {
                case (ConsoleKey.UpArrow):
                    if (position.Y > 0)
                    {
                        position.Y--;
                        return true;
                    }
                    break;
                case (ConsoleKey.LeftArrow):
                    if (position.X > 0)                    
                    {
                        position.X--;
                        return true;
                    }
                    break;
                case (ConsoleKey.DownArrow):
                    if (position.Y < 7)
                    {
                        position.Y++;
                        return true;
                    }
                    break;
                case (ConsoleKey.RightArrow):
                    if (position.X <7)
                    {
                        position.X++;
                        return true;
                    }
                    break;
            }
        }
        private void Attack()
        {
            Console.WriteLine("ATTACK!");
        }
    }
}
