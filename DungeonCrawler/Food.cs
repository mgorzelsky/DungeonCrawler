using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DungeonCrawler
{
    class Food
    {
        static Random rnd = new Random();
        private Point position;
        public Point Position { get { return position; } }
        public Food(GameObjects[,] currentBoardState)
        {
            Game.DifficultyIncreased += HandleDifficultyIncreased;
            FoodPositionGenerator(currentBoardState);
        }

        private void FoodPositionGenerator(GameObjects[,] currentBoardState)
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
        public void HandleDifficultyIncreased(object sender, EventArgs e)
        {
            Console.WriteLine("The difficulty has increased");
        }
    }
}
