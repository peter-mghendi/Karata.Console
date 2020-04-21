using System.Collections.Generic;
using System;

namespace Karata.Engine.Models
{
    interface IPlayer
    {
        public string Name { get; set; }
        public List<ICard> Cards { get; set; }
        public bool LastCard { get; set; }
        public bool LastCardSignalledThisTurn { get; }

        public void GiveCards(List<ICard> cards);
        public List<ICard> DoTurn(IGameState gameState, bool error = false);
    }
}
