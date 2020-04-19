using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System;
using Karata.Models;

namespace Karata.App
{
    class Game: IGame
    {
        public Game(List<IPlayer> players) 
        {
            Players = players;
            GameState = new GameState();
            Deck = new Deck(shuffle: true);
            Deal(4);
        }

        private Deck Deck { get; set; }
        private GameState GameState { get; set; }
        private List<IPlayer> Players { get; set; }

        public void Play()
        {
            Console.WriteLine("Game starts in 3 seconds...");
            List<Card> tempList = new List<Card>(53);
            do {
                if (!Array.Exists(Card.specialFaces, x => x == Deck.Cards.Peek().FaceValue)) {
                    GameState.Pile.Push(Deck.Cards.Pop());
                    break;
                }

                tempList.Add(Deck.Cards.Pop());
            } while (Deck.Size > 0);
            tempList.AddRange(Deck.Cards);
            Deck.Cards = new Stack<Card>(tempList);
            
            Thread.Sleep(3000);
            Console.Clear();

            int i = 0;
            do 
            {
                foreach (IPlayer player in Players)
                {
                    if(player.Cards.Count == 0) 
                    {
                        player.GiveCards(Deck.Pick());
                        Console.WriteLine($"{player.Name} picked a card.\n");
                    } 
                    else 
                    {
                        Console.WriteLine($"Current top card: {GameState.TopCard.ToString()}");
                        Console.WriteLine($"{player.Name}'s turn.\nYour Cards: \n");
                        IEnumerable<string> playerCards = player.Cards.Select((card, i) => $"{i}: {card.ToString()}");
                        Console.WriteLine(String.Join('\n', playerCards));
                        List<Card> turn = player.DoTurn(GameState);
                        turn.ForEach(x => GameState.Pile.Push(x));
                        Console.Clear();
                        
                        Console.WriteLine(String.Join('\n', turn.Select(x => $"{player.Name} played {x.ToString()}")) + "\n");
                    }

                    Console.WriteLine("Press any key to continue.");
                    _ = Console.ReadKey(true);
                    Console.Clear();
                }
                i++;
            } while(i < 6);
        }

        private void Deal(uint num) => Players.ForEach(player => player.GiveCards(Deck.Pick(num)));
    }
}
