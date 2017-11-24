using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckLib.Models
{
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        public CardSuit Suit { get; private set; }

        public CardRank Rank { get; private set; }

        public CardColour Colour
        {
            get
            {
                if (Suit == CardSuit.Spade || Suit == CardSuit.Club)
                    return CardColour.Black;
                else
                    return CardColour.Red;
            }
        }

        public static bool operator ==(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public static bool operator <(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return false;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Rank < right.Rank;
        }

        public static bool operator >(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return false;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Rank > right.Rank;
        }

        public static bool operator <=(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Rank <= right.Rank;
        }

        public static bool operator >=(Card left, Card right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if ((object)left == null || (object)right == null)
                return false;

            return left.Rank >= right.Rank;
        }

        public Card(CardSuit suit, CardRank rank)
        {
            if (suit < CardSuit.Spade || suit > CardSuit.Diamond)
                throw new ArgumentException(string.Format("Suit {0} is not a valid value for a card", (int)suit));

            if (rank < CardRank.Ace || rank > CardRank.King)
                throw new ArgumentException(string.Format("Rank {0} is not a valid value for a card", (int)rank));

            Suit = suit;
            Rank = rank;
        }

        public bool Equals(Card other)
        {
            if (other == null)
                return false;

            return Rank == other.Rank && Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode() ^ Rank.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}s", Rank, Suit);
        }

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;

            //Sort by Suit first
            //Sort by Rank if suits are equal
            if (Suit < other.Suit)
                return -1;
            else if (Suit > other.Suit)
                return 1;
            else if (Rank < other.Rank)
                return -1;
            else if (Rank > other.Rank)
                return 1;
            else
                return 0;
        }
    }
}
