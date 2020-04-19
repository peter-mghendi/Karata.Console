using System.Collections.Generic;
using System;
using Karata.App;
using Karata.Models;
using Karata.Utils;
using Karata.Exceptions;

namespace Karata
{
    class Program
    {
        public static readonly string VERSION = "1.0";

        static void Main(string[] args)
        {
            Console.WriteLine($"Karata v{VERSION}\n");
            do {
                var players = RegisterPlayers();
                IGame game = new Game(players);
                game.Play();
            } while (RunAgain());
        }

        private static bool RunAgain(bool error = false)
        {
            Console.Write($"{(error? "Error! Invalid input. ": "")}Run again? (Y/N) ");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.WriteLine($"{input.KeyChar}");
            return (input.Key == ConsoleKey.Y || input.Key == ConsoleKey.N)
                ? input.Key == ConsoleKey.Y 
                : RunAgain(true);
        }

        private static List<IPlayer> RegisterPlayers(uint max = 4) 
        {
            var players = new List<IPlayer>((int) max);
            if (max == 0) throw new ZeroException ("Cannot register zero players");
            
            uint playerCount = InputUtils.
                ReadUnsignedInt(prompt: $"How many players would you like to register? (Max {max}) ", min: 2, max: max);

            for (int i = 1; i <= playerCount; i++){
                Console.Write($"Enter player {i} name: ");
                players.Add(new HumanPlayer(Console.ReadLine()));
            }    

            return players;
        }
    }
}
