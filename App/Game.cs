using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System;
using Karata.Models;
using Karata.Engine.Models;
using Karata.Engine;
using Karata.Exceptions;

namespace Karata.App
{
    class Game: IGame
    {
        public Game(List<IPlayer> players, IEngine engine = null) 
        {
            Players = players;
            GameState = new GameState(shuffleDeck: true, engine: engine ??= new KarataEngine());
            Deal(4);
        }

        private GameState GameState { get; set; }
        private List<IPlayer> Players { get; set; }

        public void Play()
        {
            Console.WriteLine("Game starts in 3 seconds...");
            List<ICard> tempList = new List<ICard>(53);
            do {
                if (!Array.Exists(Card.specialFaces, x => x == GameState.Deck.Cards.Peek().FaceValue)) {
                    GameState.Pile.Push(GameState.Deck.Cards.Pop());
                    break;
                }

                tempList.Add(GameState.Deck.Cards.Pop());
            } while (GameState.Deck.Size > 0);

            tempList.AddRange(GameState.Deck.Cards);
            GameState.Deck.Cards = new Stack<ICard>(tempList);
            
            Thread.Sleep(3000);
            Console.Clear();

            do 
            {
                foreach (IPlayer player in Players)
                {
                    if(player.Cards.Count == 0) 
                    {
                        player.GiveCards(GameState.Deck.Pick());
                        Console.WriteLine($"{player.Name} picked a card.\n");
                    } 
                    else 
                    {
                        // This block takes care of prompting the player for an action
                        Console.WriteLine($"Deck Size: {GameState.Deck.Size}");
                        Console.WriteLine($"Current top card: {GameState.TopCard.ToString()}");
                        Console.WriteLine($"{player.Name}'s turn.\nYour Cards: \n");
                        IEnumerable<string> playerCards = player.Cards.Select((card, i) => $"{i}: {card.ToString()}");
                        Console.WriteLine(String.Join('\n', playerCards));
                        List<ICard> turn = player.DoTurn(GameState);
                        turn.ForEach(x => GameState.Pile.Push(x));
                        Console.Clear();

                        // This block takes care of displaying the results of the player's turn
                        if(turn.Count == 0) 
                        {
                            player.GiveCards(PickFromDeck());
                            Console.WriteLine($"{player.Name} picked a card.\n");
                        } 
                        
                        Console.WriteLine(String.Join('\n', turn.Select(x => $"{player.Name} played {x.ToString()}")));
                        
                        // TODO Get rid of the nested ifs
                        if (player.LastCard) 
                        {
                            if (!player.LastCardSignalledThisTurn) 
                            {
                                if (player.Cards.Count == 0) 
                                {
                                    if (Players.Any(x => x.Cards.Count > 1)) 
                                    {
                                        Console.WriteLine($"Game Over! {player.Name} wins!\n");
                                        return;
                                    }
                                    Console.WriteLine("Game cannot end because some players do not have cards");
                                }
                                player.LastCard = false;
                            } else Console.WriteLine($"{player.Name} is on their last card(s)\n");
                        }
                    }

                    Console.WriteLine("Press any key to continue.");
                    _ = Console.ReadKey(true);
                    Console.Clear();
                }
            } while(true);
        }

        private void Deal(uint num) => Players.ForEach(player => player.GiveCards(PickFromDeck(num)));

        private List<ICard> PickFromDeck(uint num = 1, uint attempts = 0) {
            if (attempts > 5) throw new AttemptsExceededException($"Unable to pick {num} cards from deck.");

            try 
            {
                return GameState.Deck.Pick(num);
            } 
            catch (InsufficientCardsException) 
            {
                Console.WriteLine("Please wait, shuffling...");
                Thread.Sleep(3000);
                
                var temp = GameState.Pile;
                GameState.Pile = new Stack<ICard>(54);
                GameState.Pile.Push(temp.Pop());

                temp.ToList().AddRange(GameState.Deck.Cards);
                GameState.Deck.Cards = new Stack<ICard>(temp);
                GameState.Deck.Shuffle();
                return PickFromDeck(num, ++attempts);
            }
        }
    }
}
