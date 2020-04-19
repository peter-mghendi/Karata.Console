using System.Threading;
using System.Linq;
using System.Security.Cryptography;
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
        public bool LastCardSignalledThisTurn { get => lastCardSignalledThisTurn; }
        private bool lastCardSignalledThisTurn;
        
        public void GiveCards(List<Card> cards) => Cards.AddRange(cards);

        public HumanPlayer(string name) {
            Name = name;
            Cards = new List<Card>();
            LastCard = false;
            lastCardSignalledThisTurn = false;
        }

        public List<Card> DoTurn(GameState gameState, bool error = false) {
            lastCardSignalledThisTurn = false;
            if (error) Console.WriteLine("That card sequence is invalid. Please try again.");
            List<Card> turnCards = new List<Card>(Cards.Count);
            List<string> choices = InputUtils
                .ReadPlayString(
                    prompt: "Select a card to play: (End with # to signal last card(s)) ", 
                    max: Convert.ToUInt32(Cards.Count - 1));

            if(choices.Count == 0) return turnCards;    

            if(choices[^1].Equals("#")) 
            {
                choices.RemoveAt(choices.Count - 1);
                lastCardSignalledThisTurn = true;
                LastCard = true;
            }

            List<int> cardIndexes = new List<int>(Cards.Count);
            choices.ForEach(x => cardIndexes.Add(int.Parse(x)));
            
            turnCards.AddRange(cardIndexes.Select(x => Cards[x]));           
            if (turnCards.Count > 0 && !ValidateTurnCards(gameState, turnCards))
                return DoTurn(gameState, error: true);

            cardIndexes.OrderByDescending(x => x).ToList().ForEach(x => Cards.RemoveAt(x));                 
            return turnCards;
        }

        private bool ValidateTurnCards(GameState gameState, List<Card> turnCards) {
            if ((turnCards[0].FaceValue & gameState.RequestCard.FaceValue) == 0) return false;
            if ((turnCards[0].SuitName & gameState.RequestCard.SuitName) == 0) return false;
            turnCards = turnCards.Prepend(gameState.TopCard).ToList();

            for (int i = 1; i < turnCards.Count; i++)
            {
                if ((turnCards[i].FaceValue & Card.FaceValues.Joker) > 0) 
                    continue;

                Card prevCard = turnCards[i-1];

                if ((turnCards[i].FaceValue & prevCard.FaceValue) == 0 &&
                    (turnCards[i].SuitName & prevCard.SuitName) == 0) 
                    return false;
            }
            return true;
        }
    }
}