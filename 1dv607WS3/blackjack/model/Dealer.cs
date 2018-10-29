using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;

        private rules.IWinnerRule m_winnerRule;

        private List<INewCardRecievedObserver> m_subscribers;
 
        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_subscribers = new List<INewCardRecievedObserver>();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                this.GiveCard(a_player, true);

                return true;
            }
            return false;
        }

        public bool Stand(Player a_player)
        {
            if (m_deck != null){
                this.ShowHand();

                foreach(Card card in this.GetHand()){
                    card.Show(true);
                }

                while(m_hitRule.DoHit(this)){
                    this.GiveCard(this, true);
                }

                return true;
            }
            return false;
        }

        public void GiveCard(Player a_player, bool show){
            foreach(INewCardRecievedObserver obs in m_subscribers){
                obs.NewCardRecieved(a_player);
            }

            Card c;
            c =  m_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);
        }

        public bool IsDealerWinner(Player a_player)
        {
            
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            if (CalcScore() > g_maxScore)
            {
                return false;
            }
            else if(CalcScore() == a_player.CalcScore()){
                return m_winnerRule.CheckWinner(this, a_player, g_maxScore);
            }
            return CalcScore() > a_player.CalcScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void AddSubscriber(INewCardRecievedObserver a_sub){
            m_subscribers.Add(a_sub);
        }
    }   
}
