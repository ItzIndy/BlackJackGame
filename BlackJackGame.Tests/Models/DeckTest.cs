using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlackJackGame.Tests.Models {
    public class DeckTest {

        [Fact]
        public void Draw_returnsBlackJackCard() {
            Deck deck = new Deck();

            Assert.IsType<BlackJackCard>(deck.Draw());
        }

        [Fact]
        public void NewDeck_Contains52BlackJackCards() {
            Deck deck = new Deck();
            int[] faceValues = new int[13];
            int[] suits = new int[4];
            for (int i= 0; i < 52; i++) {
                var bjc = deck.Draw();
                faceValues[(int)bjc.FaceValue-1]++;
                suits[(int)bjc.Suit-1]++;
            }
            for(int i = 0; i < 4; i++) {
                Assert.Equal(13, suits[i]);
            }
            for(int i = 0; i < 13; i++) {
                Assert.Equal(4, faceValues[i]);

            }
        }

        public void Draw_InvalidOperationException_NoCardsLeft() {
            Deck deck = new Deck();
            for(int i = 0; i < 52; i++) {
                deck.Draw();
            }

            Assert.Throws<InvalidOperationException>(() => deck.Draw());
        }
    }
}
