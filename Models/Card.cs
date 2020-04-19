using System;
namespace Karata.Models
{
    class Card: Suit
    {
        public Card(FaceValues faceValue, Suits suits): base(suits) => FaceValue = faceValue;

        public enum FaceValues
        {
            Ace = 1,
            Two, 
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jester,
            Queen,
            King,
            Joker 
        }

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