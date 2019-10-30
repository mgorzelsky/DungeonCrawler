using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    enum GameObjects { empty, player, enemy, wall, exit };
    class Game
    {
        public static int level = 1;

        GameObjects[,] gameBoard;
        Player player;
        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Food food;
        Walls walls;
        Renderer renderer;
        public Game()
        {
            gameBoard = new GameObjects[8, 8];
        }
        public void Start()
        {
            player = new Player();
            food = new Food();
            walls = new Walls();
            renderer = new Renderer();

            //Console.WriteLine(player.Position);

            //while (true)
            //{
            //    player.HandleInput(Console.ReadKey(true).Key);
            //    Console.WriteLine(player.Position);
            //}
        }
    }
}
