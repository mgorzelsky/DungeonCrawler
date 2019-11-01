using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    class Renderer
    {
        private Player player;
        public Renderer(Player player)
        {
            this.player = player;
        }
        public void DrawScreen()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                StringBuilder screenAsString = new StringBuilder("", 64);
                char currentCharacter = Convert.ToChar(32);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        switch (Game.gameBoard[x, y])
                        {
                            case (GameObjects.empty):
                                currentCharacter = Convert.ToChar(32);
                                break;
                            case (GameObjects.player):
                                currentCharacter = '^';
                                break;
                            case (GameObjects.wall):
                                currentCharacter = '#';
                                break;
                            case (GameObjects.enemy):
                                currentCharacter = '!';
                                break;
                            case (GameObjects.food):
                                currentCharacter = 'v';
                                break;
                            case (GameObjects.exit):
                                currentCharacter = 'X';
                                break;
                        }
                        screenAsString.Append(new char[] { currentCharacter });
                    }
                    screenAsString.Append(Environment.NewLine);
                }
                Console.Write(screenAsString);

                Console.SetCursorPosition(0, 10);
                Console.Write($"Current Food left:   {player.Food}      ");
                Console.SetCursorPosition(0, 11);
                Console.Write($"Current Level:  {Game.level}     ");
                Thread.Sleep(1000 / 60000);
            }
        }

        private void PlayerSprite()
        {/*
             O
            /Y\
            L L

            \o/
             Y
            | |
        */}
    }
}
