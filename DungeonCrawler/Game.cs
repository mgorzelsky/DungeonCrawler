using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        Walls walls;
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
            player = new Player();
            food = new Food();
            renderer = new Renderer();
            gameBoard[player.Position.X, player.Position.Y] = GameObjects.player;
            renderer.UpdateState(gameBoard);

            //Thread inputThread = new Thread(WaitForInput);
            //inputThread.Start();

            Thread renderThread = new Thread(renderer.DrawScreen);
            renderThread.Start();

            while (!gameOver) //overall game loop
            {
                listOfEnemies = new List<Enemy>();
                {
                    listOfEnemies.Add(new Enemy());
                    listOfEnemies.Add(new Enemy());
                    listOfEnemies.Add(new Enemy());
                    foreach (Enemy enemy in listOfEnemies)
                        gameBoard[enemy.Position.X, enemy.Position.Y] = GameObjects.enemy;
                }
                listOfWalls = new List<Walls>();
                {
                    listOfWalls.Add(new Walls());
                    listOfWalls.Add(new Walls());
                    listOfWalls.Add(new Walls());
                    foreach (Walls wall in listOfWalls)
                        gameBoard[wall.Position.X, wall.Position.Y] = GameObjects.wall;
                }

                while (!levelComplete) //level loop
                {
                    gameBoard = new GameObjects[8, 8];
                    foreach (Walls wall in listOfWalls)
                        gameBoard[wall.Position.X, wall.Position.Y] = GameObjects.wall;
                    foreach (Enemy enemy in listOfEnemies)
                        gameBoard[enemy.Position.X, enemy.Position.Y] = GameObjects.enemy;

                    ConsoleKey keyPressed = Console.ReadKey(true).Key;
                    bool validMove = false;
                    if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow ||
                        keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
                        validMove = player.Move(keyPressed, gameBoard);

                    if (keyPressed == ConsoleKey.Spacebar)
                        validMove = player.Attack(gameBoard);
                    gameBoard[player.Position.X, player.Position.Y] = GameObjects.player;

                    if (validMove)
                    {
                        foreach (Enemy enemy in listOfEnemies)
                            enemy.Act(gameBoard);
                    }

                    renderer.UpdateState(gameBoard);
                }
            }

            //inputThread.Join();
        }

        public virtual void OnDifficultyIncreased()
        {
            DifficultyIncreased?.Invoke(this, EventArgs.Empty);
        }
        private void HandleDifficultyIncreased(object sender, EventArgs e)
        {
                
        }
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
