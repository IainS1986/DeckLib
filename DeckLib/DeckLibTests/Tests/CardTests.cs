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

        [TestMethod]
        public void SameSuitLowerRankIsLessThan()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Spade, CardRank.King);

            //Action
            bool leftIsLower = left < right;

            //Assert
            Assert.IsTrue(leftIsLower);
        }

        [TestMethod]
        public void SameSuitHigherRankIsMoreThan()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Spade, CardRank.King);

            //Action
            bool rightIsHigher = right > left;

            //Assert
            Assert.IsTrue(rightIsHigher);
        }

        [TestMethod]
        public void DifferentSuitLowerRankIsLessThan()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Diamond, CardRank.King);

            //Action
            bool leftIsLower = left < right;

            //Assert
            Assert.IsTrue(leftIsLower);
        }

        [TestMethod]
        public void DifferentSuitHigherRankIsMoreThan()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Diamond, CardRank.King);

            //Action
            bool rightIsHigher = right > left;

            //Assert
            Assert.IsTrue(rightIsHigher);
        }

        [TestMethod]
        public void SameSuitRanksLowerOrEqual()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Spade, CardRank.King);
            Card equal = new Card(CardSuit.Spade, CardRank.Ace);

            //Action
            bool leftIsLower = left <= right;
            bool leftIsEqual = left <= equal;

            //Assert
            Assert.IsTrue(leftIsLower);
            Assert.IsTrue(leftIsEqual);
        }

        [TestMethod]
        public void DifferntSuitRanksLowerOrEqual()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Club, CardRank.King);
            Card equal = new Card(CardSuit.Diamond, CardRank.Ace);

            //Action
            bool leftIsLower = left <= right;
            bool leftIsEqual = left <= equal;

            //Assert
            Assert.IsTrue(leftIsLower);
            Assert.IsTrue(leftIsEqual);
        }

        [TestMethod]
        public void SameSuitRanksHigherOrEqual()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Spade, CardRank.King);
            Card equal = new Card(CardSuit.Spade, CardRank.Ace);

            //Action
            bool rightIsHigher = right >= left;
            bool leftIsEqual = left >= equal;

            //Assert
            Assert.IsTrue(rightIsHigher);
            Assert.IsTrue(leftIsEqual);
        }

        [TestMethod]
        public void DifferntSuitRanksHigherOrEqual()
        {
            //Arrange
            Card left = new Card(CardSuit.Spade, CardRank.Ace);
            Card right = new Card(CardSuit.Club, CardRank.King);
            Card equal = new Card(CardSuit.Diamond, CardRank.Ace);

            //Action
            bool rightIsHigher = right >= left;
            bool leftIsEqual = left >= equal;

            //Assert
            Assert.IsTrue(rightIsHigher);
            Assert.IsTrue(leftIsEqual);
        }

        [TestMethod]
        public void DifferentSuitsSameRankCompareCorrectlyWhenSorting()
        {
            //Arrange
            Card spade = new Card(CardSuit.Spade, CardRank.Ace);
            Card heart = new Card(CardSuit.Heart, CardRank.Ace);
            Card club = new Card(CardSuit.Club, CardRank.Ace);
            Card diamond = new Card(CardSuit.Diamond, CardRank.Ace);

            //Action
            int sS = spade.CompareTo(spade);
            int sH = spade.CompareTo(heart);
            int sC = spade.CompareTo(club);
            int sD = spade.CompareTo(diamond);

            int hS = heart.CompareTo(spade);
            int hH = heart.CompareTo(heart);
            int hC = heart.CompareTo(club);
            int hD = heart.CompareTo(diamond);

            int cS = club.CompareTo(spade);
            int cH = club.CompareTo(heart);
            int cC = club.CompareTo(club);
            int cD = club.CompareTo(diamond);

            int dS = diamond.CompareTo(spade);
            int dH = diamond.CompareTo(heart);
            int dC = diamond.CompareTo(club);
            int dD = diamond.CompareTo(diamond);

            //Assert
            Assert.AreEqual(0, sS);
            Assert.AreEqual(-1, sH);
            Assert.AreEqual(-1, sC);
            Assert.AreEqual(-1, sD);

            Assert.AreEqual(1, hS);
            Assert.AreEqual(0, hH);
            Assert.AreEqual(-1, hC);
            Assert.AreEqual(-1, hD);

            Assert.AreEqual(1, cS);
            Assert.AreEqual(1, cH);
            Assert.AreEqual(0, cC);
            Assert.AreEqual(-1, cD);

            Assert.AreEqual(1, dS);
            Assert.AreEqual(1, dH);
            Assert.AreEqual(1, dC);
            Assert.AreEqual(0, dD);
        }

        [TestMethod]
        public void SameSuitsDifferentRanksCompareCorrectlyWhenSorting()
        {
            //Arrange
            Card ace = new Card(CardSuit.Spade, CardRank.Ace);
            Card seven = new Card(CardSuit.Spade, CardRank.Seven);
            Card king = new Card(CardSuit.Spade, CardRank.King);

            //Action
            int aS = ace.CompareTo(seven);
            int aK = ace.CompareTo(king);
            int aA = ace.CompareTo(ace);

            int sA = seven.CompareTo(ace);
            int sS = seven.CompareTo(seven);
            int sK = seven.CompareTo(king);

            int kA = king.CompareTo(ace);
            int kS = king.CompareTo(seven);
            int kK = king.CompareTo(king);

            //Assert
            Assert.AreEqual(-1, aS);
            Assert.AreEqual(-1, aK);
            Assert.AreEqual(0, aA);

            Assert.AreEqual(1, sA);
            Assert.AreEqual(0, sS);
            Assert.AreEqual(-1, sK);

            Assert.AreEqual(1, kA);
            Assert.AreEqual(1, kS);
            Assert.AreEqual(0, kK);
        }

        [TestMethod]
        public void SameSuitCourtCardsCompareCorrectlyWhenSorting()
        {
            //Arrange
            Card ten = new Card(CardSuit.Spade, CardRank.Ten);
            Card jack = new Card(CardSuit.Spade, CardRank.Jack);
            Card queen = new Card(CardSuit.Spade, CardRank.Queen);
            Card king = new Card(CardSuit.Spade, CardRank.King);

            //Action
            int tenLessThanJack = ten.CompareTo(jack);
            int jackLessThanQueen = jack.CompareTo(queen);
            int queenLessThanKing = queen.CompareTo(king);

            //Assert
            Assert.AreEqual(-1, tenLessThanJack);
            Assert.AreEqual(-1, jackLessThanQueen);
            Assert.AreEqual(-1, queenLessThanKing);
        }

        [TestMethod]
        public void SuitsSortBeforeRanksWhenComparing()
        {
            //Arrange
            Card one = new Card(CardSuit.Spade, CardRank.King);
            Card two = new Card(CardSuit.Heart, CardRank.Ace);

            //Action
            int oneLessThanTwo = one.CompareTo(two);

            //Assert
            Assert.AreEqual(-1, one.CompareTo(two));
        }
    }
}
