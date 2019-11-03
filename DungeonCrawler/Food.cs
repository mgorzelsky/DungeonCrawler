using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DungeonCrawler
{
    class Food
    {
        private Point position;
        public Point Position { get { return position; } }
        public Food()
        {
            FoodPositionGenerator();
        }

        private void FoodPositionGenerator()
        {
            while (true)
            {
                position.X = Game.rnd.Next(0, 8);
                position.Y = Game.rnd.Next(0, 8);
                if (Game.gameBoard[position.X, position.Y] == GameObjects.empty)
                    return;
            }
        }
    }
}
