using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace DungeonCrawler
{
    enum GameObjects { empty, player, enemy, food,  wall, exit };
    class Game
    {
        public static GameObjects[,] gameBoard;
        public static int level = 1;
        public static bool gameOver = false;
        public static bool levelComplete = false;
        static Random rnd = new Random();

        public static event EventHandler DifficultyIncreased;
        Player player;
        Food food;
        Renderer renderer;
        private List<Enemy> listOfEnemies;
        private List<Walls> listOfWalls;

        public Game()
        {
            gameBoard = new GameObjects[8, 8];
            Game.DifficultyIncreased += HandleDifficultyIncreased;
        }

        public void Start()
        {
            player = new Player(DungeonCrawlerProgram.game);
            renderer = new Renderer(player);

            gameBoard = new GameObjects[8, 8];

            Thread renderThread = new Thread(renderer.DrawScreen);
            renderThread.Start();

            while (!gameOver) //overall game loop
            {
                levelComplete = false;
                gameBoard = new GameObjects[8, 8];

                player.ResetPosition();
                gameBoard[player.Position.X, player.Position.Y] = GameObjects.player;
                gameBoard[7, 0] = GameObjects.exit;

                listOfWalls = new List<Walls>();
                WallBuilder(3);

                listOfEnemies = new List<Enemy>();
                EnemyBuilder(1);

                food = new Food();
                gameBoard[food.Position.X, food.Position.Y] = GameObjects.food;

                while (!levelComplete) //level loop
                {
                    SetupGameboard();

                    bool validMove = WaitForInput();

                    SetupGameboard();

                    if (validMove)
                    {
                        foreach (Enemy enemy in listOfEnemies)
                        {
                            Thread.Sleep(100);
                            enemy.Move(rnd.Next(0, 4));
                            enemy.Act();
                        }
                    }

                    SetupGameboard();

                    CheckCollisions();
                }
                level++;
                Thread.Sleep(500);
            }
        }

        private void SetupGameboard()
        {
            gameBoard = new GameObjects[8, 8];

            if (food != null)
                gameBoard[food.Position.X, food.Position.Y] = GameObjects.food;
            gameBoard[7, 0] = GameObjects.exit;
            foreach (Walls wall in listOfWalls)
                gameBoard[wall.Position.X, wall.Position.Y] = GameObjects.wall;
            foreach (Enemy enemy in listOfEnemies)
                gameBoard[enemy.Position.X, enemy.Position.Y] = GameObjects.enemy;
            gameBoard[player.Position.X, player.Position.Y] = GameObjects.player;
        }

        private void CheckCollisions()
        {
            Point p = new Point(7,0);
            if (food != null)
            {
                if (player.Position == food.Position)
                {
                    player.Eat();
                    food = null;
                }
            }
            if (player.Position.Equals(p))
                levelComplete = true;
        }

        private bool WaitForInput()
        {
            ConsoleKey keyPressed = Console.ReadKey(true).Key;
            if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow ||
                keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
                return player.Move(keyPressed);

            return false;
        }

        private void EnemyBuilder(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                listOfEnemies.Add(new Enemy(player));
                gameBoard[listOfEnemies[i].Position.X, listOfEnemies[i].Position.Y] = GameObjects.enemy;
            }
        }

        private void WallBuilder(int numberOfWalls)
        {
            for (int i = 0; i < numberOfWalls; i++)
            {
                listOfWalls.Add(new Walls());
                gameBoard[listOfWalls[i].Position.X, listOfWalls[i].Position.Y] = GameObjects.wall;
            }
        }

        public void RemoveWallAt(Point p)
        {
            for (int i = 0; i < listOfWalls.Count; i++)
            {
                if (listOfWalls[i].Position.X == p.X && listOfWalls[i].Position.Y == p.Y)
                    listOfWalls.RemoveAt(i);
            }
        }

        public virtual void OnDifficultyIncreased()
        {
            DifficultyIncreased?.Invoke(this, EventArgs.Empty);
        }
        private void HandleDifficultyIncreased(object sender, EventArgs e)
        {
                
        }


        
        //Thread inputThread = new Thread(WaitForInput);
        //inputThread.Start();

        //inputThread.Join();

        //private void WaitForInput()
        //{
        //    while (!gameOver)
        //    {
        //        ConsoleKey keyPressed = Console.ReadKey(true).Key;
        //        bool validMove = false;

        //        if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow ||
        //            keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
        //            validMove = player.Move(keyPressed, gameBoard);

        //        if (keyPressed == ConsoleKey.Spacebar)
        //            validMove = player.Attack(gameBoard);
        //    }
        //}
    }
}
