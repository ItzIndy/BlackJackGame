using BlackJackGame.Models;
using System;
using System.Collections.Generic;

namespace BlackJackGame {
    public class Deck {
        #region Fields
        private Random _random;
        protected IList<BlackJackCard> _cards;
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
            if (_cards.Count != 0) {
                var card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }
            else {
                throw new InvalidOperationException("Deck is leeg!");
            }
        }

        public void Shuffle() {
            Random r = new Random();
            for(int i = _cards.Count-1; i > 0; i--) {
                int random = r.Next(i);
                int temp = i;
                _cards[i] = _cards[random];
                _cards[random] = _cards[random]; 

            }

        }
        #endregion
    }
}
