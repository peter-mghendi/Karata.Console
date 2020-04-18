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
                Game game = new Game();
                game.Play();
            } while (RunAgain());
        }

        private static bool RunAgain(bool error = false)
        {
            Console.Write($"{(error? "\nError! Invalid input. ": "")}Run again? (Y/N) ");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.WriteLine($"{input.KeyChar}\n");
            return Array.Exists(new[] {ConsoleKey.Y, ConsoleKey.N}, x => x == input.Key)? input.Key == ConsoleKey.Y: RunAgain(true);
        }
    }
}
