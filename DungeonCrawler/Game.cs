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
        public static Random rnd = new Random();

        //public static event EventHandler DifficultyIncreased;
        Player player;
        Renderer renderer;
        private bool levelComplete = false;
        private List<Enemy> listOfEnemies;
        private List<Walls> listOfWalls;
        private List<Food> listOfFood;

        public Game()
        {
            gameBoard = new GameObjects[8, 8];
            //Game.DifficultyIncreased += HandleDifficultyIncreased;
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
                EnemyBuilder();

                listOfFood = new List<Food>();
                FoodBuilder();

                while (!levelComplete && !gameOver) //level loop
                {
                    SetupGameboard();

                    bool validMove = WaitForInput();

                    SetupGameboard();

                    if (validMove)
                    {
                        Thread.Sleep(50);
                        foreach (Enemy enemy in listOfEnemies)
                        {
                            enemy.Move(rnd.Next(0, 4));
                            enemy.Act();
                        }
                    }

                    SetupGameboard();

                    CheckCollisions();

                    if (player.Food < 1)
                        gameOver = true;
                }
                level++;
                Thread.Sleep(500);
            }
            renderThread.Join();
        }

        private void SetupGameboard()
        {
            gameBoard = new GameObjects[8, 8];

            if (listOfFood != null)
                foreach (Food food in listOfFood)
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
            for (int i = 0; i < listOfFood.Count; i++)
            {
                if (listOfFood[i] != null)
                {
                    if (player.Position == listOfFood[i].Position)
                    {
                        player.Eat();
                        listOfFood[i] = null;
                    }
                }
            }
            if (player.Position.Equals(p))
                levelComplete = true;
        }

        private bool WaitForInput()
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
            if (Console.KeyAvailable != true)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.LeftArrow ||
                    keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.RightArrow)
                    return player.Move(keyPressed);
            }

            return false;
        }

        private void EnemyBuilder()
        {
            int numberOfEnemies = 0;
            if (level < 5)
                numberOfEnemies = 0;
            else if (level < 10)
                numberOfEnemies = 1;
            else if (level < 15)
                numberOfEnemies = 2;
            else if (level >= 15)
                numberOfEnemies = 3;

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

        private void FoodBuilder()
        {
            int numberOfFoods;
            int foodSpawnChanceModifier = 80;
            if (level < 10)
                numberOfFoods = 2;
            else
                numberOfFoods = 1;

            if (level % 2 == 0 && foodSpawnChanceModifier > 10)
                foodSpawnChanceModifier -= 2;
            for (int i = 0; i < numberOfFoods; i++)
            {
                if (rnd.Next(0, 100) < foodSpawnChanceModifier)
                    listOfFood.Add(new Food());
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

        //public virtual void OnDifficultyIncreased()
        //{
        //    DifficultyIncreased?.Invoke(this, EventArgs.Empty);
        //}
        //private void HandleDifficultyIncreased(object sender, EventArgs e)
        //{
                
        //}


        
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
