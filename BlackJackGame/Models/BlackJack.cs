using System;

namespace BlackJackGame.Models {
    public class BlackJack {

        private Deck _deck;
        public const bool FaceDown = false;
        public const bool FaceUp = true;



        public Hand DealerHand { get; set; }
        public Hand PlayerHand { get; set; }
        public GameState GameState { get; set; }


        public BlackJack(Deck deck) {
            this._deck = deck;
            GameState = GameState.PlayerPlays;
            DealerHand = new Hand();
            PlayerHand = new Hand();
            Deal();
            //FIXING ACE BUG
            if (PlayerHand.Value == 11) {
                PlayerHand.Value = 21;
                GameState = GameState.GameOver;
            }

        }

        public void PassToDealer() {
            AdjustGameState();
            DealerHand.TurnAllCardsFaceUp();
           
            AddCardToHand(DealerHand, true);
            AdjustGameState();
            
            


        }

        public string GameSummary() {
            string temp = null;
            if (PlayerHand.Value > 21) {
                temp = "Player Burned, Dealer Wins";
            }
            else if ((PlayerHand.Value == 21 || PlayerHand.Value == 11) && GameState == GameState.GameOver) {
                temp = "BLACKJACK";
            }
            else if (DealerHand.Value > 21 && GameState == GameState.GameOver) {
                temp = "Dealer Burned, player wins";
            }
            else if (PlayerHand.Value == DealerHand.Value && GameState == GameState.GameOver) {
                temp = "Equal, dealer wins";
            }
            else if (PlayerHand.Value > DealerHand.Value && PlayerHand.Value < 21 && GameState == GameState.GameOver) {
                temp = "Player Wins";
            }
            else if (DealerHand.Value > PlayerHand.Value && DealerHand.Value < 21 && GameState == GameState.GameOver) {
                temp = "Dealer Wins";
            }
            return temp;
        }

        public void GivePlayerAnotherCard() {
            if (GameState != GameState.PlayerPlays) {
                throw new InvalidOperationException();
            }
            AddCardToHand(PlayerHand, true);
        }

        private void AddCardToHand(Hand hand, bool faceUp) {
            BlackJackCard c = _deck.Draw();
            if (faceUp) {
                c.TurnCard();
            }

            hand.AddCard(c);
        }

        private void AdjustGameState() {
            if (DealerHand.Value > 21 || PlayerHand.Value > 21) {
                GameState = GameState.GameOver;
            }
            if (GameState == GameState.PlayerPlays) {
                GameState = GameState.DealerPlays;
            }
            if (PlayerHand.Value == DealerHand.Value) {
                GameState = GameState.GameOver;
            }
        }




        private void Deal() {
            AddCardToHand(DealerHand, true);
            AddCardToHand(DealerHand, false);
            AddCardToHand(PlayerHand, true);
            AddCardToHand(PlayerHand, true);


            PlayerHand.TurnAllCardsFaceUp();
        }

        private void LetDealerFinalize() {
            if (GameState == GameState.GameOver) {
                AddCardToHand(DealerHand, false);
                AdjustGameState();
            }
        }
    }


}

