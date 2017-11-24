using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckLib.Models
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

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
    }
}
