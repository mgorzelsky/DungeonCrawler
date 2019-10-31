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
        Food food;
        Walls walls;
        Renderer renderer;
        public Game()
        {
            gameBoard = new GameObjects[8, 8];
            Game.DifficultyIncreased += HandleDifficultyIncreased;
        }

        public void Start()
        {
            player = new Player();
            food = new Food();
            walls = new Walls();
            renderer = new Renderer();
            renderer.UpdateState(gameBoard);

            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();

            Thread renderThread = new Thread(renderer.DrawScreen);
            renderThread.Start();

            while (!gameOver)
            {
                gameBoard = new GameObjects[8, 8];
                gameBoard[player.Position.X, player.Position.Y] = GameObjects.player;
                renderer.UpdateState(gameBoard);
            }

            inputThread.Join();
        }
        private void WaitForInput()
        {
            while (!gameOver)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                bool validMove = player.HandleInput(keyPressed);
            }
        }
        public virtual void OnDifficultyIncreased()
        {
            DifficultyIncreased?.Invoke(this, EventArgs.Empty);
        }
        private void HandleDifficultyIncreased(object sender, EventArgs e)
        {
                
        }
    }
}
