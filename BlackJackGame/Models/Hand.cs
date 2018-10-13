using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models {
    public class Hand {
        private IList<BlackJackCard> _cards;

        public IEnumerable<BlackJackCard> Cards { get { return _cards; } }
        public int NrOfCards { get { return _cards.Count; } }
        public int Value { get { return CalculateValue(); } set { } }

        public Hand() {
            _cards = new List<BlackJackCard>();
        }

        public void AddCard(BlackJackCard blackJackCard) {
            _cards.Add(blackJackCard);
        }
        
        public void TurnAllCardsFaceUp() {
            foreach(BlackJackCard temp in Cards) {
                if(!temp.FaceUp)
                 temp.TurnCard();
            }

        }

        private int CalculateValue() {
            int value = 0;
            for(int i = 0; i < _cards.Count; i++) {
                value = value + _cards[i].Value;
            }
            return value;
        }
    }
}
