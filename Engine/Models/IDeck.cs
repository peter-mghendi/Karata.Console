using System.Collections.Generic;

namespace Karata.Engine.Models
{
    interface IDeck
    {
        public Stack<ICard> Cards { get; set; }
        public uint Size { get; }

        public void Shuffle();

        public List<ICard> Pick(uint num = 1);
    }
}