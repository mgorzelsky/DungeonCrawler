using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    enum GameObjects { empty, player, enemy, wall, exit };
    class Game
    {
        public static int level = 1;
        public static bool gameOver = false;

        public static event EventHandler DifficultyIncreased;
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

            while (true)
            {
                ConsoleKey k = Console.ReadKey().Key;
                if (k == ConsoleKey.Spacebar)
                    OnDifficultyIncreased();
                else
                    Console.WriteLine("The difficulty is the same");
            }

            //inputThread.Join();
        }
        private void WaitForInput()
        {
            while (!gameOver)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                player.HandleInput(keyPressed);

                Console.WriteLine(player.Position);
            }
        }
        public virtual void OnDifficultyIncreased()
        {
            DifficultyIncreased?.Invoke(this, EventArgs.Empty);
        }
    }
}
