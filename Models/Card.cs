using System;
namespace Karata.Models
{
    class Card: Suit
    {
        public Card(FaceValues faceValue, Suits suits): base(suits) => FaceValue = faceValue;

        // TODO Function to automatically assign these
        public enum FaceValues
        {
            Ace = 1,
            Two = 2, 
            Three = 4,
            Four = 8,
            Five = 16,
            Six = 32,
            Seven = 64,
            Eight = 128,
            Nine = 256,
            Ten = 512,
            Jester = 1024,
            Queen = 2048,
            King = 4196,
            Joker = 8192,
            Any = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jester | Queen | King | Joker
        }

        // Convenience constants
        public static readonly Card AnyCard = new Card(FaceValues.Any, Suit.Suits.Any),
            AnySpade = new Card(FaceValues.Any, Suit.Suits.Spades),
            AnyHeart = new Card(FaceValues.Any, Suit.Suits.Hearts),
            AnyClub = new Card(FaceValues.Any, Suit.Suits.Clubs),     
            AnyDiamond = new Card(FaceValues.Any, Suit.Suits.Diamonds);


        public static FaceValues[] specialFaces = new FaceValues[] {
            FaceValues.Ace, FaceValues.Two, FaceValues.Three,
            FaceValues.Eight, FaceValues.Jester, FaceValues.Queen,
            FaceValues.King, FaceValues.Joker
        };

        public FaceValues FaceValue { get; set; }

        public override string ToString() => FaceValue == FaceValues.Joker 
            ? Enum.GetName(typeof(FaceValues), FaceValue) 
            : $"{Enum.GetName(typeof(FaceValues), FaceValue)} of {Enum.GetName(typeof(Suits), SuitName)}";
    }
}