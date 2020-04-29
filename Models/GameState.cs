using System.Collections.Generic;
using Karata.Engine.Models;
using Karata.Engine;

namespace Karata.Models
{
    class GameState: IGameState
    {
        public GameState(bool shuffleDeck = false, IEngine engine = null) 
        {
            Engine = engine ?? new KarataEngine();
            Pile = new Stack<ICard>(54);
            RequestCard = Card.AnyCard;
            Deck = new Deck(shuffleDeck);
        }

        public IEngine Engine { get; set; }
        public Stack<ICard> Pile { get; set; }
        public ICard TopCard { get => Pile.Peek(); }
        public ICard RequestCard { get; set; }
        public IDeck Deck { get; set; }
    }
}