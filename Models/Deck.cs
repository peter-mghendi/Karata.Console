using System;
using System.Linq;
using System.Collections.Generic;
using Karata.Engine.Models;
using Karata.Exceptions;
namespace Karata.Models
{
    class Deck: IDeck
    {
        // TODO Observer pattern for deck cards exhausted
        public Deck(bool shuffle = false) {
            // Push standard cards into deck
            // TODO Get rid of magic constants
            Stack<ICard> cardDeck = new Stack<ICard>(54);
            var suitValues = Enum.GetValues(typeof(SuitValues)).Cast<SuitValues>();
            var faceValues = Enum.GetValues(typeof(FaceValues)).Cast<FaceValues>().Take(13);
            foreach (SuitValues suit in suitValues) {
                if (Array.Exists(Suit.specialSuits, x => x == suit)) continue;
                foreach (FaceValues face in faceValues) 
                    cardDeck.Push(new Card(face, suit));
            }

            cardDeck.Push(new Card(FaceValues.Joker, SuitValues.Black));
            cardDeck.Push(new Card(FaceValues.Joker, SuitValues.Red));       

            Cards = cardDeck;   
            if(shuffle) Shuffle();     
        }

        private static Random random = new Random();

        public Stack<ICard> Cards { get; set; }
        public uint Size { get => Convert.ToUInt32(Cards.Count); }

        // TODO Better shuffle algorithm
        // REF Fisher-Yates Algorithm/Knuth Shuffle
        public void Shuffle() => Cards = new Stack<ICard>(Cards.OrderBy(_ => random.Next()));

        public List<ICard> Pick(uint num = 1) {
            if(num > Size) throw new InsufficientCardsException("Too few cards in deck");

            List<ICard> picked = new List<ICard>();
            for(int i = 0; i < num; i++) 
                picked.Add(Cards.Pop());

            return picked;    
        }
    }
}