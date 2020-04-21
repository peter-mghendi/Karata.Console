using System;
using Karata.Engine.Models;

namespace Karata.Models
{
    class Card: Suit, ICard
    {
        public Card(FaceValues faceValue, SuitValues suitvalues): base(suitvalues) => FaceValue = faceValue;

        // Convenience constants
        public static readonly Card AnyCard = new Card(FaceValues.Any, SuitValues.Any),
            AnySpade = new Card(FaceValues.Any, SuitValues.Spades),
            AnyHeart = new Card(FaceValues.Any, SuitValues.Hearts),
            AnyClub = new Card(FaceValues.Any, SuitValues.Clubs),     
            AnyDiamond = new Card(FaceValues.Any, SuitValues.Diamonds);


        public static FaceValues[] specialFaces = new FaceValues[] {
            FaceValues.Ace, FaceValues.Two, FaceValues.Three,
            FaceValues.Eight, FaceValues.Jester, FaceValues.Queen,
            FaceValues.King, FaceValues.Joker
        };

        public FaceValues FaceValue { get; set; }

        public override string ToString() => FaceValue == FaceValues.Joker 
            ? Enum.GetName(typeof(FaceValues), FaceValue) 
            : $"{Enum.GetName(typeof(FaceValues), FaceValue)} of {Enum.GetName(typeof(SuitValues), SuitValue)}";
    }
}