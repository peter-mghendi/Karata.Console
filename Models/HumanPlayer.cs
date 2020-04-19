using System;
using System.Collections.Generic;
using Karata.Utils;

namespace Karata.Models
{
    class HumanPlayer: IPlayer
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public bool LastCard { get; set; }
        
        public void GiveCards(List<Card> cards) => Cards.AddRange(cards);

        public HumanPlayer(string name) {
            Name = name;
            Cards = new List<Card>();
            LastCard = false;
        }

        // TODO Accept game state rather than a single card
        public List<Card> DoTurn(GameState gameState) {
            List<Card> turnCards = new List<Card>(Cards.Count);
            // TODO Do turn
            int choice = InputUtils.ReadSignedInt(prompt: "Select a card to play: ", min: 0, max: Cards.Count - 1);
            turnCards.Add(Cards[choice]);
            Cards.RemoveAt(choice);
            return turnCards;
        }

        private bool VerifyTurnCards(GameState gameState, List<Card> turnCards) {
            // TODO Verify turn cards
            return true;
        }
    }
}