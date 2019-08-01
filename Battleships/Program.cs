using System;
using System.Collections.Generic;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            //The program can be extended by asking the user for the grid configuration
            List<int> gridConfiguration = new List<int> {5, 4, 4};

            Game game = new Game(gridConfiguration);
            game.Start();

            Console.ReadLine();
        }       
    }
}
