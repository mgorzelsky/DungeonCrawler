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

        public bool Move(ConsoleKey direction, GameObjects[,] currentBoardState)
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
            return false;
        }
        public bool Attack(GameObjects[,] currentBoardState)
        {
            //If player is next to a wall return true, else return false.
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("ATTACK!");
            return true;
        }
    }
}
