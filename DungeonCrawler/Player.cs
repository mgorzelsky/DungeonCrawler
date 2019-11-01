using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace DungeonCrawler
{
    class Player
    {
        private Point position;
        public Point Position { get { return position; } }
        private int food;
        public int Food { get { return food; } }
        public Player()
        {
            ResetPosition();
            this.food = 100;
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
                        if (currentBoardState[position.X, position.Y - 1] == GameObjects.empty ||
                            currentBoardState[position.X, position.Y - 1] == GameObjects.food ||
                            currentBoardState[position.X, position.Y - 1] == GameObjects.exit)
                        {
                            position.Y--;
                            return true;
                        }
                    }
                    break;
                case (ConsoleKey.LeftArrow):
                    if (position.X > 0)                    
                    {
                        if (currentBoardState[position.X - 1, position.Y] == GameObjects.empty ||
                            currentBoardState[position.X - 1, position.Y] == GameObjects.food ||
                            currentBoardState[position.X - 1, position.Y] == GameObjects.exit)
                        {
                            position.X--;
                            return true;
                        }
                    }
                    break;
                case (ConsoleKey.DownArrow):
                    if (position.Y < 7)
                    {
                        if (currentBoardState[position.X, position.Y + 1] == GameObjects.empty ||
                            currentBoardState[position.X, position.Y + 1] == GameObjects.food ||
                            currentBoardState[position.X, position.Y + 1] == GameObjects.exit)
                        {
                            position.Y++;
                            return true;
                        }
                    }
                    break;
                case (ConsoleKey.RightArrow):
                    if (position.X <7)
                    {
                        if (currentBoardState[position.X + 1, position.Y] == GameObjects.empty ||
                            currentBoardState[position.X + 1, position.Y] == GameObjects.food ||
                            currentBoardState[position.X + 1, position.Y] == GameObjects.exit)
                        {
                            position.X++;
                            return true;
                        }
                    }
                    break;
            }
            Debug.WriteLine("That was not a valid move.");
            return false;
        }
        public bool Attack(GameObjects[,] currentBoardState)
        {
            //If player is next to a wall return true, else return false.
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("ATTACK!");
            return true;
        }

        public void Eat()
        {
            food += 15;
            Debug.WriteLine("Om nom nom nom...");
        }

        public void TakeDamage()
        {
            food -= 10;
            Debug.WriteLine("owwwwww!");
        }
    }
}
