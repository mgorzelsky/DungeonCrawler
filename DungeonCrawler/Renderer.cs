using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace DungeonCrawler
{
    class Renderer
    {
        private ulong renderCount = 0;
        private int animationStep = 0;
        private Player player;
        public Renderer(Player player)
        {
            this.player = player;
        }
        //public void DrawBoard()
        //{
        //    string boardGrid = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n" +
        //                       "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@-----+-----+-----+-----+-----+-----+-----+-----@@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@     |     |     |     |     |     |     |     @@\n" +
        //                       "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n" +
        //                       "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@";
        //    Console.SetCursorPosition(0, 0);
        //    Console.Write(boardGrid);
        //}

        //public void DrawScreen()
        //{
        //    while (!Game.gameOver)
        //    {
        //        Console.SetCursorPosition(0, 0);
        //        StringBuilder screenAsString = new StringBuilder("", 64);
        //        char currentCharacter = Convert.ToChar(32);
        //        for (int y = 0; y < 8; y++)
        //        {
        //            for (int x = 0; x < 8; x++)
        //            {
        //                switch (Game.gameBoard[x, y])
        //                {
        //                    case (GameObjects.empty):
        //                        currentCharacter = Convert.ToChar(32);
        //                        break;
        //                    case (GameObjects.player):
        //                        currentCharacter = '^';
        //                        break;
        //                    case (GameObjects.wall):
        //                        currentCharacter = '#';
        //                        break;
        //                    case (GameObjects.enemy):
        //                        currentCharacter = '!';
        //                        break;
        //                    case (GameObjects.food):
        //                        currentCharacter = 'v';
        //                        break;
        //                    case (GameObjects.exit):
        //                        currentCharacter = 'X';
        //                        break;
        //                }
        //                screenAsString.Append(new char[] { currentCharacter });
        //            }
        //            screenAsString.Append(Environment.NewLine);
        //        }
        //        Console.Write(screenAsString);

        //        //Console.SetCursorPosition(0, 10);
        //        //Console.Write($"Current Food left:   {player.Food}      ");
        //        //Console.SetCursorPosition(0, 11);
        //        //Console.Write($"Current Level:  {Game.level}     ");
        //        Thread.Sleep(1000 / 60000);
        //    }
        //}

        public void DrawScreen()
        {
            while (!Game.gameOver)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        switch (Game.gameBoard[x, y])
                        {
                            case (GameObjects.empty):
                                DrawEmpty(x, y);
                                break;
                            case (GameObjects.wall):
                                DrawWall(x, y);
                                break;
                            case (GameObjects.exit):
                                DrawExit(x, y);
                                break;
                            case (GameObjects.food):
                                DrawFood(x, y);
                                break;
                            case (GameObjects.player):
                                DrawPlayer(x, y);
                                break;
                            case (GameObjects.enemy):
                                DrawEnemy(x, y);
                                break;
                        }
                    }
                    Thread.Sleep(1000 / 120);
                    renderCount++;
                    if (renderCount % 60 == 0)
                        animationStep++;
                }
            }
        }


        private void DrawEmpty(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string emptyTexture1 = "`````";
            string emptyTexture2 = "`````";
            string emptytexture3 = "`````";

            Console.SetCursorPosition(x, y);
            Console.Write(emptyTexture1, Color.DarkOliveGreen);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(emptyTexture2, Color.DarkOliveGreen);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(emptytexture3, Color.DarkOliveGreen);
        }
        private void DrawPlayer(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string playerTexture1;
            string playerTexture2;
            string playerTexture3;
            if (animationStep % 2 == 0)
            {
                playerTexture1 = @"  O/ ";
                playerTexture2 = @" /|  ";
                playerTexture3 = @" / \ ";
            }
            else
            {
                playerTexture1 = @" \O  ";
                playerTexture2 = @"  |\ ";
                playerTexture3 = @" / \ ";
            }

            Console.SetCursorPosition(x, y);
            Console.Write(playerTexture1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(playerTexture2);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(playerTexture3);
        }
        private void DrawEnemy(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string enemyTexture1 = @"     ";
            string enemyTexture2 = @". - .";
            string enemyTexture3 = @"     ";

            Console.SetCursorPosition(x, y);
            Console.Write(enemyTexture1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(enemyTexture2);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(enemyTexture3);
        }
        private void DrawWall(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string wallTexture1 = @"+---+";
            string wallTexture2 = @"|%%%|";
            string wallTexture3 = @"+---+";

            Console.SetCursorPosition(x, y);
            Console.Write(wallTexture1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(wallTexture2);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(wallTexture3);
        }
        private void DrawFood(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string foodTexture1 = @"F    ";
            string foodTexture2 = @" O  D";
            string foodTexture3 = @"  O  ";

            Console.SetCursorPosition(x, y);
            Console.Write(foodTexture1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(foodTexture2);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(foodTexture3);
        }
        private void DrawExit(int x, int y)
        {
            x = (x + 1) * 5;
            y = (y + 1) * 3;
            string exitTexture1 = @"EXIT ";
            string exitTexture2 = @" EXIT";
            string exitTexture3 = @"EXIT ";

            Console.SetCursorPosition(x, y);
            Console.Write(exitTexture1);
            Console.SetCursorPosition(x, y + 1);
            Console.Write(exitTexture2);
            Console.SetCursorPosition(x, y + 2);
            Console.Write(exitTexture3);
        }
    }
}
