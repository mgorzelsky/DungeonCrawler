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
        public Food()
        {
            //Game.DifficultyIncreased += HandleDifficultyIncreased;
            FoodPositionGenerator();
        }

        private void FoodPositionGenerator()
        {
            while (true)
            {
                position.X = rnd.Next(0, 8);
                position.Y = rnd.Next(0, 8);
                if (Game.gameBoard[position.X, position.Y] == GameObjects.empty)
                    return;
            }
        }
        //public void HandleDifficultyIncreased(object sender, EventArgs e)
        //{
        //    Console.WriteLine("The difficulty has increased");
        //}
    }
}
