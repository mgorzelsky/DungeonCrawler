using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DungeonCrawler
{
    class Player : Entity
    {
        private Point playerPosition;
        public Point PlayerPosition { get { return playerPosition; } }
        public Player()
        {
            ResetPosition();
        }

        //Player always starts in the bottom left corner
        private void ResetPosition()
        {
            playerPosition.X = 0;
            playerPosition.Y = 7;
        }
    }
}
