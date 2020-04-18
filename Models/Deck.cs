using System;
using System.Linq;
using System.Collections.Generic;

namespace Karata.Models
{
    class Deck
    {
        public Deck(bool shuffle = false) {
            Stack<Card> cardDeck = new Stack<Card>();
            var suitValues = Enum.GetValues(typeof(Suit.Suits)).Cast<Suit.Suits>();
            var faceValues = Enum.GetValues(typeof(Card.FaceValues)).Cast<Card.FaceValues>();
            foreach (var suit in suitValues)
                foreach (var face in faceValues) {
                    if (face == Card.FaceValues.Joker) 
                        continue;

                    cardDeck.Push(new Card(face, suit));
                }

            cardDeck.Push(new Card(Card.FaceValues.Joker, Suit.Suits.Spades | Suit.Suits.Clubs));
            cardDeck.Push(new Card(Card.FaceValues.Joker, Suit.Suits.Hearts | Suit.Suits.Diamonds));       

            Cards = cardDeck;   
            if(shuffle) Shuffle();     
        }

        private static Random random = new Random();

        public Stack<Card> Cards { get; set; }
        public uint Size { get => Convert.ToUInt32(Cards.Count); }

        // TODO Better shuffle algorithm
        // REF Fisher-Yates Algorithm/Knuth Shuffle
        public void Shuffle() => Cards.OrderBy(x => random.Next());

        public List<Card> Pick(uint num = 1) {
            // TODO Custom Exceptions
            if(num > Size) throw new Exception("Too few cards in deck");

            List<Card> picked = new List<Card>();
            for(int i = 0; i < num; i++) 
                picked.Add(Cards.Pop());

            return picked;    
        }
    }
}