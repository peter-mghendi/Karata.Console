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

        public FaceValues FaceValue { get; set; }
    }
}