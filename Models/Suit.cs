using System;

namespace Karata.Models
{
    class Suit
    {
        protected Suit(Suits suitName) => SuitName = suitName;

        public enum SuitColors
        {
            Black,
            Red
        }

        public enum Suits
        {
            Spades = 1,
            Hearts = 2,
            Clubs = 4,
            Diamonds = 8,
            Black = Spades | Clubs, 
            Red = Hearts | Diamonds,
            Any = Black | Red
        }

        public static readonly Suits[] specialSuits = {Suits.Black, Suits.Red, Suits.Any};

        public Suits SuitName { get; set; }

        public SuitColors SuitColor { 
            get => (((SuitName & Suits.Spades) > 0) || ((SuitName & Suits.Clubs) > 0))? 
                SuitColors.Black: SuitColors.Red;
        }
    }
}