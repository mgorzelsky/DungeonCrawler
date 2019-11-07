using System;
using System.IO;

namespace DungeonCrawler
{
    class DungeonCrawlerProgram
    {
        public static Game game;
        public static int width = 100;
        public static int height = 25;
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;

            string[] escapeFromDarkForestSplash = File.ReadAllLines(@"EscapeFromDarkForestSplash.txt");
            string contributers = "Contributers: Michael Gorzelsky";
            string instructions = "Press the Up Arrow or Spacebar to flap higher";

            DrawGenericScreen(escapeFromDarkForestSplash, (width - escapeFromDarkForestSplash[3].Length) / 2, 2);
            DrawGenericScreen(contributers, (width - contributers.Length) / 2, height - 1);
            DrawGenericScreen(instructions, (width - instructions.Length) / 2, height / 2);

            Console.CursorVisible = false;
            game = new Game();
            game.Start();
        }

        static void DrawGenericScreen(string thingToDraw, int widthOffset, int heightOffset)
        {
            Console.SetCursorPosition(widthOffset, heightOffset);
            foreach (char character in thingToDraw)
            {
                if (character.Equals('\0'))
                {
                    heightOffset++;
                    Console.SetCursorPosition(widthOffset, heightOffset);
                }
                if (!character.Equals('\0'))
                    Console.Write(character);
            }
        }

        static void DrawGenericScreen(string[] thingToDraw, int widthOffset, int heightOffset)
        {
            Console.SetCursorPosition(widthOffset, heightOffset);
            foreach (string line in thingToDraw)
            {
                Console.SetCursorPosition(widthOffset, heightOffset);
                Console.Write(line);
                heightOffset++;
            }
        }
    }
}
