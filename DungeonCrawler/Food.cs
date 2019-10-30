using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    class Food
    {
        public Food()
        {
            Game.DifficultyIncreased += HandleDifficultyIncreased;
        }
        public void HandleDifficultyIncreased(object sender, EventArgs e)
        {
            Console.WriteLine("The difficulty has increased");
        }
    }
}
