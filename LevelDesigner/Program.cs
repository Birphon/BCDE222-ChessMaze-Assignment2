using System;
using System.Collections.Generic;
using System.Text;

namespace LevelDesigner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Level levelDesigner = new Level();
            levelDesigner.SaveMe();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
