using System.Linq;
using System.Collections.Generic;
using Karata.Engine.Models; 

namespace Karata.Engine
{
    class KarataEngine: IEngine
    {
        public bool ValidateTurnCards(IGameState gameState, List<ICard> turnCards) {
            // If a card has been requested, that card must start the turn.
            if ((turnCards[0].FaceValue & gameState.RequestCard.FaceValue) == 0) return false;
            if ((turnCards[0].SuitValue & gameState.RequestCard.SuitValue) == 0) return false;

            turnCards = turnCards.Prepend(gameState.TopCard).ToList();

            for (int i = 1; i < turnCards.Count; i++)
            {
                ICard prevCard = turnCards[i-1];

                // The Joker card should allow any card on either side
                if ((turnCards[i].FaceValue & FaceValues.Joker) > 0 ||
                    (prevCard.FaceValue & FaceValues.Joker) > 0) 
                    continue;

                // First card should match current top card suit or value
                if (i == 1 &&
                    (turnCards[i].FaceValue & prevCard.FaceValue) == 0 &&
                    (turnCards[i].SuitValue & prevCard.SuitValue) == 0)
                    return false;

                // Every subequent card should match previous card value 
                if (i > 1 && (turnCards[i].FaceValue & prevCard.FaceValue) == 0)
                    return false;
            }
            return true;
        }
    }
}