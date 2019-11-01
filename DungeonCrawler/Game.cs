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
        public static int level = 1;
        public static bool gameOver = false;
        public static bool levelComplete = false;

        public static event EventHandler DifficultyIncreased;
        GameObjects[,] gameBoard;
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
            renderer = new Renderer();

            gameBoard = new GameObjects[8, 8];
            renderer.UpdateState(gameBoard);

            //Thread renderThread = new Thread(renderer.DrawScreen);
            //renderThread.Start();

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

                food = new Food(gameBoard);
                gameBoard[food.Position.X, food.Position.Y] = GameObjects.food;

                renderer.UpdateState(gameBoard);
                renderer.DrawScreen(player.Food);


                while (!levelComplete) //level loop
                {
                    gameBoard = new GameObjects[8, 8];
                    SetupGameboard();

                    bool validMove = WaitForInput();

                    if (validMove)
                    {
                        foreach (Enemy enemy in listOfEnemies)
                            enemy.Act(gameBoard);
                    }

                    gameBoard = new GameObjects[8, 8];
                    SetupGameboard();

                    renderer.UpdateState(gameBoard);
                    CheckCollisions();
                    renderer.DrawScreen(player.Food);
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }

        private void SetupGameboard()
        {
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
                return player.Move(keyPressed, gameBoard);

            //if (keyPressed == ConsoleKey.Spacebar)
            //{
            //    player.Attack(gameBoard, ref listOfWalls);
            //    return true;
            //}

            return false;
        }

        private void EnemyBuilder(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                listOfEnemies.Add(new Enemy(gameBoard, player));
                gameBoard[listOfEnemies[i].Position.X, listOfEnemies[i].Position.Y] = GameObjects.enemy;
            }
            //foreach (Enemy enemy in listOfEnemies)
            //    gameBoard[enemy.Position.X, enemy.Position.Y] = GameObjects.enemy;

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
