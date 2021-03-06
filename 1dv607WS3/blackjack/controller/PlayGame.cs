﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.INewCardRecievedObserver
    {
        public bool Play(model.Game a_game, view.IView a_view)
        
        {
            a_game.AddDealerSubscriber(this);

            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());

            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            int input = a_view.GetInput();

            if (a_view.WantsToPlay(input))
            {
                a_game.NewGame();
            }
            else if (a_view.WantsToHit(input))
            {
                a_game.Hit();
            }
            else if (a_view.WantsToStand(input))
            {
                a_game.Stand();
            }
            else if (a_view.WantsToQuit(input)){
                return false;
            }

            return true;
        }

        public void Pause(model.Player a_player){
            
        }   
    }
}
