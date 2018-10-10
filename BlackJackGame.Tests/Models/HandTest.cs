using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models {

    public class HandTest {
        private Hand _aHand;

        public HandTest() {
            _aHand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards() {
            Assert.Equal(0, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard() {
            //Arrange
            
            Deck deck = new Deck();
            
            //Act 
            _aHand.AddCard(deck.Draw());

            //Assert
            Assert.Equal(1, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_AHandWithCards_AddsACard() {
            //Assert
            Deck deck = new Deck();

            //Act
            _aHand.AddCard(deck.Draw());
            _aHand.AddCard(deck.Draw());

            //Assert
            Assert.Equal(2, _aHand.NrOfCards);
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp() {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Three));
            _aHand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _aHand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact]
        public void Value_EmptyHand_IsZero() {
            //No assert - no act
            //Act
            Assert.Equal(0, _aHand.Value);
        }

        [Fact]
        public void Value_HandWith6and5_Is11() {
            //No assert
            //Act
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Six));
            _aHand.AddCard(new BlackJackCard(Suit.Hearts, FaceValue.Five));
            _aHand.TurnAllCardsFaceUp();
            //Assert
            Assert.Equal(11, _aHand.Value);
            
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWith5AndKing_Is15() {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown() {
        }

        [Fact(Skip = "Not yet implemented")]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11() {
        }

        [Fact(Skip = "Not yet implemented")]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1() {
        }
    }
}
