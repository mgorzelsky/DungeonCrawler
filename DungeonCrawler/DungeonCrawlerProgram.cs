using System;

namespace DungeonCrawler
{
    class DungeonCrawlerProgram
    {
        public static Game game;
        static void Main()
        {
            Console.CursorVisible = false;
            game = new Game();
            game.Start();
        }
    }
}
