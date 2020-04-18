using System.Collections.Generic;
using System;

namespace Karata.Models
{
    interface IPlayer
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public bool LastCard { get; set; }

        public List<Card> DoTurn(GameState gameState);
    }
}
