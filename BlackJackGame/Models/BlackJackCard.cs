using System;

namespace BlackJackGame.Models {
    public class BlackJackCard : Card {
        #region Properties
        public bool FaceUp { get; private set; }
        public int Value {
            get {

                return FaceUp ? Math.Min((int)FaceValue, 10) : 0;
            }
        }
        #endregion


        #region Constructor
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue) {
            FaceUp = false;
        }
        #endregion

        #region Methods
        public void TurnCard() {
            FaceUp = !FaceUp;
        }
        #endregion
    }
}
