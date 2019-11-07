using System;
using System.IO;
using System.Threading;

namespace DungeonCrawler
{
    class DungeonCrawlerProgram
    {
        public static Game game;
        public static int width = 100;
        public static int height = 33;
        static void Main()
        {
            Console.Clear();
            Console.SetCursorPosition((width - 81) / 2, 0);
            Console.Write("Adjust your window size to see the lower message at the same time as this message");
            Console.SetCursorPosition((width - 24) / 2, height / 2);
            Console.Write("Press any key when ready");
            Console.SetCursorPosition((width - 81) / 2, height);
            Console.Write("Adjust your window size to see the upper message at the same time as this message");

            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = false;

            string[] escapeFromDarkForestSplash = File.ReadAllLines(@"txt\EscapeFromDarkForestSplash.txt");
            string contributers = "Contributers: Michael Gorzelsky";

            DrawGenericScreen(escapeFromDarkForestSplash, (width - escapeFromDarkForestSplash[0].Length) / 2, 0);
            DrawGenericScreen(contributers, (width - contributers.Length) / 2, height);

            Thread.Sleep(5000);

            string[] storyText = File.ReadAllLines(@"txt\StoryText.txt");
            int iterationCount = 0;
            foreach (string line in storyText)
            {
                WriteTextProcedurally(line, iterationCount);
                iterationCount++;
                Thread.Sleep(500);
            }
            Thread.Sleep(2000);



            Console.Clear();
            Console.CursorVisible = false;
            game = new Game();
            game.Start();
        }

        private static void WriteTextProcedurally(string line, int iterationCount)
        {
            Console.SetCursorPosition((width - line.Length) / 2, ((height / 2) - 2) + iterationCount);
            foreach (char character in line)
            {
                Console.Write(character);
                Thread.Sleep(75);
            }
        }

        private static void DrawGenericScreen(string thingToDraw, int widthOffset, int heightOffset)
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

        private static void DrawGenericScreen(string[] thingToDraw, int widthOffset, int heightOffset)
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
