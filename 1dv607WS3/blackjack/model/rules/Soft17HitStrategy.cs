using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            IEnumerable<Card> hand = a_dealer.GetHand();

            foreach(Card card in hand){
                //checks if the dealer has a soft 17 hand.
                if(card.GetValue() == BlackJack.model.Card.Value.Ace && a_dealer.CalcScore() == g_hitLimit){
                    return true;
                }
            }

            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}