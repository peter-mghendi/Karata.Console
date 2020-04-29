using System.Collections.Generic;
namespace Karata.Engine.Models
{
    interface IEngine
    {
        public bool ValidateTurnCards(IGameState gameState, List<ICard> turnCards);

        public void ProcessPostTurnActions(IGameState gameState, List<ICard> turnCards, out uint pickedCards);
    }
}