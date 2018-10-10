using BlackJackGame.Models;
using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Deck {
        #region Fields
        private Random _random;
        private IList<BlackJackCard> _cards;
        #endregion

        #region Constructor
        public Deck() {
            _cards = new List<BlackJackCard>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                    _cards.Add(new BlackJackCard(suit, faceValue));
        }
        #endregion

        #region Methods
        public BlackJackCard Draw() {
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public void Shuffle() {
            throw new NotImplementedException();

        }
        #endregion
    }
}
