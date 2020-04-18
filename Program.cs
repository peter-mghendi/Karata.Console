using System;
using Karata.App;

namespace Karata
{
    class Program
    {
        public static readonly string VERSION = "1.0";

        static void Main(string[] args)
        {
            Console.WriteLine($"Karata v{VERSION}\n");
            do {
                // TODO Pass a Rules object to Game constructor... possibly Dictionary<Rule, bool>
                Game game = new Game();
                game.Play();
            } while (RunAgain());
        }

        private static bool RunAgain(bool error = false)
        {
            Console.Write($"{(error? "\nError! Invalid input. ": "")}Run again? (Y/N) ");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.WriteLine($"{input.KeyChar}\n");
            return (input.Key == ConsoleKey.Y || input.Key == ConsoleKey.N)
                ? input.Key == ConsoleKey.Y 
                : RunAgain(true);
        }
    }
}
