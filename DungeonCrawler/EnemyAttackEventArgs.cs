using System;
using System.Drawing;

namespace DungeonCrawler
{
    public class EnemyAttackEventArgs : EventArgs
    {
        public Point Position { get; set; }
    }
}