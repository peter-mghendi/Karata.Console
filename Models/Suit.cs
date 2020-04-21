using System;
using Karata.Engine.Models;
namespace Karata.Models
{
    class Suit: ISuit
    {
        protected Suit(SuitValues suitValue) => SuitValue = suitValue;

        public static readonly SuitValues[] specialSuits = {SuitValues.Black, SuitValues.Red, SuitValues.Any};

        public SuitValues SuitValue { get; set; }

        public SuitColors SuitColor { 
            get => (((SuitValue & SuitValues.Spades) > 0) || ((SuitValue & SuitValues.Clubs) > 0))? 
                SuitColors.Black: SuitColors.Red;
        }
    }
}