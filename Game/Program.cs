using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game newGame = new Game();
            newGame.Start();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
