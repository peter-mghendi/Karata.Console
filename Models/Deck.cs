using System;
using System.Linq;
using System.Collections.Generic;
using Karata.Exceptions;

namespace Karata.Models
{
    class Deck
    {
        public Deck(bool shuffle = false) {
            // Push standard cards into deck
            // TODO Get rid of magic constants
            Stack<Card> cardDeck = new Stack<Card>(54);
            var suitValues = Enum.GetValues(typeof(Suit.Suits)).Cast<Suit.Suits>();
            var faceValues = Enum.GetValues(typeof(Card.FaceValues)).Cast<Card.FaceValues>().Take(13);
            foreach (Suit.Suits suit in suitValues) {
                if (Array.Exists(Suit.specialSuits, x => x == suit)) continue;
                foreach (Card.FaceValues face in faceValues) 
                    cardDeck.Push(new Card(face, suit));
            }

            cardDeck.Push(new Card(Card.FaceValues.Joker, Suit.Suits.Black));
            cardDeck.Push(new Card(Card.FaceValues.Joker, Suit.Suits.Red));       

            Cards = cardDeck;   
            if(shuffle) Shuffle();     
        }

        private static Random random = new Random();

        public Stack<Card> Cards { get; set; }
        public uint Size { get => Convert.ToUInt32(Cards.Count); }

        // TODO Better shuffle algorithm
        // REF Fisher-Yates Algorithm/Knuth Shuffle
        public void Shuffle() => Cards = new Stack<Card>(Cards.OrderBy(_ => random.Next()));

        public List<Card> Pick(uint num = 1) {
            if(num > Size) throw new InsufficientCardsException("Too few cards in deck");

            List<Card> picked = new List<Card>();
            for(int i = 0; i < num; i++) 
                picked.Add(Cards.Pop());

            return picked;    
        }
    }
}