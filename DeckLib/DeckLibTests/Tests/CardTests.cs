using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckLib.Models;

namespace DeckLibTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void SameCardsAreCorrectlyEqualWhenEqualsMethodUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Club, CardRank.Three);

            //Action
            bool isEqual = left.Equals(right);

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void SameCardsAreCorrectlyEqualWhenOpperandIsUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Club, CardRank.Three);

            //Action
            bool isEqual = left == right;

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void SameSuitButDifferentRankAreCorrectlyInEqualWhenEqualsMethodUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Club, CardRank.Four);

            //Action
            bool isEqual = left.Equals(right);

            //Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void SameSuitButDifferentRankAreCorrectlyInEqualWhenOperrandIsUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Club, CardRank.Four);

            //Action
            bool isEqual = left != right;

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void SameRankButDifferentSuitAreCorrectlyInEqualWhenEqualsMethodUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Spade, CardRank.Three);

            //Action
            bool isEqual = left.Equals(right);

            //Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void SameRankButDifferentSuitAreCorrectlyInEqualWhenOperrandIsUsed()
        {
            //Arrange
            Card left = new Card(CardSuit.Club, CardRank.Three);
            Card right = new Card(CardSuit.Spade, CardRank.Three);

            //Action
            bool isEqual = left != right;

            //Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void SuitsHaveTheCorrectColours()
        {
            //Arrange
            Card spade = new Card(CardSuit.Spade, CardRank.Ace);
            Card club = new Card(CardSuit.Club, CardRank.Ace);
            Card heart = new Card(CardSuit.Heart, CardRank.Ace);
            Card diamond = new Card(CardSuit.Diamond, CardRank.Ace);

            //Action
            CardColour spadeCol = spade.Colour;
            CardColour clubCol = club.Colour;
            CardColour heartCol = heart.Colour;
            CardColour diamondCol = diamond.Colour;

            //Assert
            Assert.AreEqual(CardColour.Black, spadeCol);
            Assert.AreEqual(CardColour.Black, clubCol);
            Assert.AreEqual(CardColour.Red, heartCol);
            Assert.AreEqual(CardColour.Red, diamondCol);
        }

        [TestMethod]
        public void CardToStringIsInExpectedFormat()
        {
            //Arrange
            Card ace = new Card(CardSuit.Spade, CardRank.Ace);
            Card rank = new Card(CardSuit.Club, CardRank.Two);
            Card jack = new Card(CardSuit.Heart, CardRank.Jack);
            Card diamond = new Card(CardSuit.Diamond, CardRank.King);
            string aceString = "Ace of Spades";
            string rankString = "Two of Clubs";
            string jackString = "Jack of Hearts";
            string diamondString = "King of Diamonds";

            //Action
            string aceResult = ace.ToString();
            string rankResult = rank.ToString();
            string jackResult = jack.ToString();
            string diamondResult = diamond.ToString();

            //Assert
            Assert.AreEqual(aceString, aceResult);
            Assert.AreEqual(rankString, rankResult);
            Assert.AreEqual(jackString, jackResult);
            Assert.AreEqual(diamondString, diamondResult);
        }
    }
}
