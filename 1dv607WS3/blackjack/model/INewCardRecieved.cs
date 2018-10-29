using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface INewCardRecievedObserver
    {
        void NewCardRecieved(Player a_player);
    }
}
