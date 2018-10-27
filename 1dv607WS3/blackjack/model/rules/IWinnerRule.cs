using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinnerRule
    {
          bool CheckWinner(Dealer a_dealer, Player a_player, int g_maxScore);
    }
}