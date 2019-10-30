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

        public void DrawScreen()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                        Console.Write(state[x, y]);
                    Console.Write("\n");
                }
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
