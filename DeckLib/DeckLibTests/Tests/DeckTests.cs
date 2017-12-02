using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeckLibTests
{
    [TestClass]
    public class DeckTests
    {

        [TestMethod]
        public void DecksAreCreatedInNewDeckOrder()
        {
            //Arrange
            List<Card> newDeckOrder = new List<Card>();

            //Action
            Deck deck = new Deck();

            //Assert
            AssertNewDeckOrder(deck);
        }

        [TestMethod]
        public void DeckCanBeCreatedFromPredefinedCardStack()
        {
            //Arrange
            List<Card> newCards = GetPacket();

            //Action
            Deck deck = new Deck(newCards);

            //Assert
            for(int i=0; i<newCards.Count; i++)
            {
                Assert.AreEqual(newCards[i], deck.Cards[i]);
            }
        }

        [TestMethod]
        public void AddCardSucceedsWhenNotDuplicate()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action
            deck.AddCard(new Card(CardSuit.Diamond, CardRank.Ace));

            //Assert
            Assert.AreEqual(5, deck.Cards.Count);
            Assert.AreEqual(CardSuit.Diamond, deck.Cards[deck.Cards.Count - 1].Suit);
            Assert.AreEqual(CardRank.Ace, deck.Cards[deck.Cards.Count - 1].Rank);
        }

        [TestMethod]
        public void AddDuplicateCardSucceedsWhenNotDuplicateBlocked()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action
            deck.AddCard(new Card(CardSuit.Club, CardRank.Three));

            //Assert
            Assert.AreEqual(5, deck.Cards.Count);
            Assert.AreEqual(CardSuit.Club, deck.Cards[deck.Cards.Count - 1].Suit);
            Assert.AreEqual(CardRank.Three, deck.Cards[deck.Cards.Count - 1].Rank);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Deck can't contain two cards of type Three of Clubs")]
        public void AddDuplicateCardFailsWhenDuplicatesBlocked()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action and Assert
            deck.AddCard(new Card(CardSuit.Club, CardRank.Three), true);
        }

        [TestMethod]
        public void RemoveCardSucceedsWhenCardExistsToBeRemoved()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action
            bool didRemove = deck.RemoveCard(cards[0]);

            //Assert
            Assert.IsTrue(didRemove);
            Assert.AreEqual(3, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Any(x => (x.Suit == CardSuit.Spade) && (x.Rank == CardRank.Ace)));
        }

        [TestMethod]
        public void RemoveCardFailsWhenCardDoesNotExistsToBeRemoved()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Card card = new Card(CardSuit.Spade, CardRank.Two);
            Deck deck = new Deck(cards);

            //Action
            bool didRemove = deck.RemoveCard(card);

            //Assert
            Assert.IsFalse(didRemove);
            Assert.AreEqual(4, deck.Cards.Count);
        }

        [TestMethod]
        public void RemoveCardAtFailsWhenIndexTooHigh()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action
            bool didRemove = deck.RemoveCardAt(cards.Count + 1);

            //Assert
            Assert.IsFalse(didRemove);
            Assert.AreEqual(4, deck.Cards.Count);
        }

        [TestMethod]
        public void RemoveCardAtSucceeds()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Card card = cards[1];
            Deck deck = new Deck(cards);

            //Action
            bool didRemove = deck.RemoveCardAt(1);

            //Assert
            Assert.IsTrue(didRemove);
            Assert.AreEqual(3, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Any(x => x.Suit == card.Suit && x.Rank == card.Rank));
        }

        [TestMethod]
        public void RemoveAllSucceeds()
        {
            //Arrange
            List<Card> cards = GetPacket();
            cards.Add(new Card(CardSuit.Spade, CardRank.Two));
            Deck deck = new Deck(cards);

            //Action
            int removeAll = deck.RemoveAll((x) => x.Suit == CardSuit.Spade);

            //Assert
            Assert.AreEqual(2, removeAll);
            Assert.AreEqual(3, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Any(x => x.Suit == CardSuit.Spade));
        }

        [TestMethod]
        public void ClearingADeckRemovesAllCards()
        {
            //Arrange
            List<Card> cards = GetPacket();
            Deck deck = new Deck(cards);

            //Action
            deck.Clear();

            //Assert
            Assert.AreEqual(0, deck.Cards.Count);
        }

        [TestMethod]
        public void CallingShuffleZeroTimesDoesNothingToTheOrder()
        {
            //Arrange
            Deck deck = new Deck();

            //Action
            deck.Shuffle(0);

            //Assert
            AssertNewDeckOrder(deck);
        }

        [TestMethod]
        public void CallingShuffleOnADeckRearrangesTheCards()
        {
            //Arrange
            Deck deck = new Deck();
            Deck deck2 = new Deck();

            //Action
            deck.Shuffle();

            //Assert
            AssertNewDeckOrder(deck2);
            CollectionAssert.AreNotEqual(deck.Cards, deck2.Cards);
        }

        [TestMethod]
        public void CallingShuffleCanProduceDifferentResults()
        {
            //Arrange
            Deck deck = new Deck();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();

            //Action
            deck.Shuffle();
            deck2.Shuffle();

            //Assert
            AssertNewDeckOrder(deck3);
            CollectionAssert.AreNotEqual(deck.Cards, deck2.Cards);
            CollectionAssert.AreNotEqual(deck.Cards, deck3.Cards);
            CollectionAssert.AreNotEqual(deck2.Cards, deck3.Cards);
        }

        [TestMethod]
        public void CallingFaroZeroTimesDoesNothingToTheOrder()
        {
            //Arrange
            Deck deck = new Deck();

            //Action
            deck.Faro(0);

            //Assert
            AssertNewDeckOrder(deck);
        }

        [TestMethod]
        public void CallingFaroOnADeckRearrangesTheCards()
        {
            //Arrange
            Deck deck = new Deck();
            Deck deck2 = new Deck();

            //Action
            deck.Faro();

            //Assert
            AssertNewDeckOrder(deck2);
            CollectionAssert.AreNotEqual(deck.Cards, deck2.Cards);
        }

        [TestMethod]
        public void CallingFaroProducesTheSameResultsFromTheSameStartingDeck()
        {
            //Arrange
            Deck deck = new Deck();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();

            //Action
            deck.Faro();
            deck2.Faro();

            //Assert
            AssertNewDeckOrder(deck3);
            CollectionAssert.AreEqual(deck.Cards, deck2.Cards);
            CollectionAssert.AreNotEqual(deck.Cards, deck3.Cards);
            CollectionAssert.AreNotEqual(deck2.Cards, deck3.Cards);
        }

        [TestMethod]
        public void CallingFaroShuffleEightTimesReturnsToNewDeckOrder()
        {
            //Arrange
            Deck deck = new Deck();

            //Action
            deck.Faro(8);

            //Assert
            AssertNewDeckOrder(deck);
        }

        [TestMethod]
        public void PeekReturnsNullWhenNoCardsInDeck()
        {
            //Arrange
            Deck deck = new Deck(new List<Card>());

            //Action
            Card peek = deck.Peek();

            //Assert
            Assert.IsNull(peek);
        }

        [TestMethod]
        public void PeekReturnsTopCard()
        {
            //Arrange
            List<Card> packet = GetPacket();
            Deck deck = new Deck(packet);

            //Action
            Card peek = deck.Peek();

            //Assert
            Assert.IsNotNull(peek);
            Assert.AreEqual(packet[0], peek);
        }

        [TestMethod]
        public void PeekDoesNotRemoveACard()
        {
            //Arrange
            List<Card> packet = GetPacket();
            Deck deck = new Deck(packet);

            //Action
            Card peek = deck.Peek();

            //Assert
            Assert.IsNotNull(peek);
            Assert.AreEqual(4, deck.Cards.Count);
        }

        [TestMethod]
        public void PopReturnsNullWhenNoCardsInDeck()
        {
            //Arrange
            Deck deck = new Deck(new List<Card>());

            //Action
            Card pop = deck.Pop();

            //Assert
            Assert.IsNull(pop);
        }

        [TestMethod]
        public void PopReturnsTopCard()
        {
            //Arrange
            List<Card> packet = GetPacket();
            Card topCard = packet[0];
            Deck deck = new Deck(packet);

            //Action
            Card pop = deck.Pop();

            //Assert
            Assert.IsNotNull(pop);
            Assert.AreEqual(topCard, pop);
        }

        [TestMethod]
        public void PopRemovesTopCard()
        {
            //Arrange
            List<Card> packet = GetPacket();
            Deck deck = new Deck(packet);

            //Action
            Card pop = deck.Pop();

            //Assert
            Assert.IsNotNull(pop);
            Assert.AreEqual(3, deck.Cards.Count);
            Assert.IsFalse(deck.Cards.Any(x => x.Suit == pop.Suit && x.Rank == pop.Rank));
        }

        [TestMethod]
        public void PushAddsCardToTopOfDeck()
        {
            //Arrange
            List<Card> packet = GetPacket();
            Deck deck = new Deck(packet);
            Card top = new Card(CardSuit.Spade, CardRank.Two);

            //Action
            deck.Push(top);

            //Assert
            Assert.AreEqual(5, deck.Cards.Count);
            Assert.AreEqual(top, deck.Cards[deck.Cards.Count - 1]);
        }

        [TestMethod]
        public void SortingADeckPutsItIntoNewDeckOrder()
        {
            //Arrange
            Deck deck = new Deck();
            Deck shuffled = new Deck();
            shuffled.Shuffle();

            // Assert shuffle
            AssertNewDeckOrder(deck);
            CollectionAssert.AreNotEqual(deck.Cards, shuffled.Cards);

            //Action
            shuffled.Sort();

            //Assert
            AssertNewDeckOrder(deck);
            AssertNewDeckOrder(shuffled);

        }

        private List<Card> GetPacket()
        {
            return new List<Card>()
            {
                new Card(CardSuit.Spade, CardRank.Ace),
                new Card(CardSuit.Club, CardRank.Three),
                new Card(CardSuit.Heart, CardRank.Ten),
                new Card(CardSuit.Diamond, CardRank.King)
            };
        }

        private void AssertNewDeckOrder(Deck deck)
        {
            CardSuit[] suits = new CardSuit[4] { CardSuit.Spade, CardSuit.Heart, CardSuit.Club, CardSuit.Diamond };
            CardRank[] ranks = new CardRank[13] { CardRank.Ace, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Jack, CardRank.Queen, CardRank.King };

            int c = 0;
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    Card card = deck.Cards[c++];
                    Assert.AreEqual(suits[i], card.Suit);
                    Assert.AreEqual(ranks[j], card.Rank);
                }
            }
        }
    }
}
