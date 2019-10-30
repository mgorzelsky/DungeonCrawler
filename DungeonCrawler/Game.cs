using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    enum GameObjects { empty, player, enemy, wall, exit };
    class Game
    {
        public static int level = 1;
        public static bool gameOver = false;

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

            while (level < 5 && !gameOver)
            {
                //Console.WriteLine("No enemies");
                level++;
            }

            enemy1 = new Enemy();
            Console.WriteLine(enemy1.Position);
            while (level < 15 && !gameOver)
            {
                //Console.WriteLine("One Enemy");
                level++;
            }

            enemy2 = new Enemy();
            Console.WriteLine(enemy2.Position);
            while (level < 25 && !gameOver)
            {
                //Console.WriteLine("Two Enemies");
                level++;
            }

            enemy3 = new Enemy();
            Console.WriteLine(enemy3.Position);
            while (!gameOver)
            {
                //Console.WriteLine("Three Enemies");
                level++;
            }
            //Console.WriteLine(player.Position);

            //while (true)
            //{
            //    player.HandleInput(Console.ReadKey(true).Key);
            //    Console.WriteLine(player.Position);
            //}
        }
    }
}
