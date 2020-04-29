using System.Collections.Generic;

namespace Karata.Engine.Models {
    interface IGameState
    {
        public IEngine Engine { get; set; }
        public Stack<ICard> Pile { get; set; }
        public ICard TopCard { get; }
        public ICard RequestCard { get; set; }
        public IDeck Deck { get; set; }
    }
}