using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckLib.Models
{
    public class Deck
    {
        static Random sRand = new Random();

        public List<Card> Cards { get; private set; } = new List<Card>();

        public Deck()
        {

            //Setup a deck of 52 cards by default (New Deck Order)
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var ranks = Enum.GetValues(typeof(CardRank)).Cast<CardRank>();

            foreach(var suit in suits)
            {
                foreach(var rank in ranks)
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }

        public void AddCard(Card c, bool blockDuplicates = false)
        {
            if (blockDuplicates &&
                Cards.Any(x => x == c))
                throw new ArgumentException(string.Format("Deck can't contain two cards of type {0}", c));

            Cards.Add(c);
        }

        public bool RemoveCard(Card c)
        {
            if(Cards.Any(x => x == c))
            {
                Cards.Remove(c);
                return true;
            }

            return false;
        }

        public bool RemoveCardAt(int i)
        {
            if (i >= Cards.Count)
                return false;

            Cards.RemoveAt(i);
            return true;
        }

        public int RemoveAll(Predicate<Card> match)
        {
            return Cards.RemoveAll(match);
        }

        public void Clear()
        {
            Cards.Clear();
        }

        //Fisher Yates shuffle
        public void Shuffle(int count = 1)
        {
            if (count <= 0)
                return;

            for(int i=0; i< count; i++)
            {
                for (int n = Cards.Count - 1; n > 0; --n)
                {
                    int k = sRand.Next(n + 1);
                    Card temp = Cards[n];
                    Cards[n] = Cards[k];
                    Cards[k] = temp;
                }
            }
        }

        //Not needed but I like my card magic, this does a perfect Out Faro Shuffle
        public void Faro(int count = 1)
        {
            if (count <= 0)
                return;

            //Faro fucntion to find the index of the new card x
            //is  f(x) = (2^k)x(mod51) where k is number of shuffles and x is the index of the card
            //Annoyingly this breaks for the last card, as it will try to put it at index 0. So i've hacked that a bit

            //Make a copy of the deck, and faro this into current deck
            List<Card> copy = new List<Card>();
            foreach (var c in Cards)
                copy.Add(new Card(c.Suit, c.Rank));

            //Array for replacement
            Card[] newOrder = new Card[copy.Count];

            for(int i=0; i<copy.Count; i++)
            {
                if(i == copy.Count - 1)
                {
                    newOrder[i] = copy[i];
                }
                else
                {
                    int index = (int)((Math.Pow(2, count) * i) % (Cards.Count - 1));

                    //We are moving i to index
                    newOrder[index] = copy[i];
                }
            }

            Cards = newOrder.ToList();
        }

        public Card Peek()
        {
            if (Cards.Count > 0)
                return Cards[0];
            else
                return null;
        }

        public Card Pop()
        {
            Card card = null;
            if(Cards.Count > 0)
            {
                card = Cards[0];
                Cards.RemoveAt(0);
            }
            return card;
        }

        public void Push(Card card)
        {
            Cards.Add(card);
        }

        public void Deal(List<Deck> hands, int cardsPerHand = -1)
        {
            if (hands == null || hands.Count == 0)
                return;

            int total = Cards.Count;
            if (cardsPerHand != -1)
                total = cardsPerHand * hands.Count;

            for(int i=0; i<total; i++)
            {
                if (Cards.Count == 0)
                    break;

                int hand = i % hands.Count;

                hands[hand].Cards.Add(Pop());
            }
        }

        public void Sort()
        {
            //This uses the IComparable implementation of Card
            Cards.Sort();
        }
    }
}
