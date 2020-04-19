using System.Collections.Generic;
namespace Karata.Models
{
    class GameState
    {
        public GameState() 
        {
            // TODO Get rid of magic constants
            Pile = new Stack<Card>(54);
            RequestCard = Card.AnyCard;
        }

        public Stack<Card> Pile { get; set; }
        public Card TopCard { get => Pile.Peek(); }
        public Card RequestCard { get; set; }
    }
}