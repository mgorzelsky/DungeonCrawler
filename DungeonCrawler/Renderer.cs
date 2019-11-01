using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    class Renderer
    {
        GameObjects[,] state;

        public void UpdateState(GameObjects[,] state)
        {
            this.state = state;
        }

        public void DrawScreen(int foodLevel)
        {
            //while (true)
            //{
                Console.SetCursorPosition(0, 0);
                StringBuilder screenAsString = new StringBuilder("", 64);
                char currentCharacter = Convert.ToChar(32);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        switch (state[x, y])
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
            Console.Write($"Current Food left:   {foodLevel}      ");
            //}
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
