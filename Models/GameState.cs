using System.Collections.Generic;
namespace Karata.Models
{
    class GameState
    {
        public Stack<Card> Pile { get; set; }
        Card CurrentCard { get => Pile.Peek(); }
        Card RequestCard { get; set; }
    }
}