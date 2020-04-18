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
            Deck = new Deck(true);
            Deal(4);
        }

        private Deck Deck { get; set; }
        private GameState GameState { get; set; }
        private List<IPlayer> Players { get; set; }

        public void Play()
        {
            Console.WriteLine("[WIP]");
        }

        private void Deal(uint num) => Players.ForEach(player => player.GiveCards(Deck.Pick(num)));
    }
}
