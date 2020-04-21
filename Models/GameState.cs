using System.Collections.Generic;
using Karata.Engine.Models;

namespace Karata.Models
{
    class GameState: IGameState
    {
        public GameState(bool shuffleDeck = false) 
        {
            // TODO Get rid of magic constants
            Pile = new Stack<ICard>(54);
            RequestCard = Card.AnyCard;
            Deck = new Deck(shuffleDeck);
        }

        public Stack<ICard> Pile { get; set; }
        public ICard TopCard { get => Pile.Peek(); }
        public ICard RequestCard { get; set; }
        public IDeck Deck { get; set; }
    }
}