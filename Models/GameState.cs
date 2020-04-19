using System.Collections.Generic;
namespace Karata.Models
{
    class GameState
    {
        public GameState() => Pile = new Stack<Card>(54);

        public Stack<Card> Pile { get; set; }
        public Card TopCard { get => Pile.Peek(); }
        public Card RequestCard { get; set; }
    }
}