using System;

namespace DungeonCrawler
{
    class DungeonCrawlerProgram
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Start();
        }
    }
}
