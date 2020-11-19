using System;

namespace examination3
{
    /// <summary>
    /// Class representing a card in the deck
    /// </summary>
    struct Card
    {
        /// <summary>
        /// Auto-implemented property to get the cards rank from enum
        /// </summary>
        public Rank Rank { get; }

        /// <summary>
        /// Auto-implemented property to get the cards suit from enum
        /// </summary>
        public Suit Suit { get; }

        /// <summary>
        /// Gets the cards value
        /// </summary>
        public int Value => (int) Rank;

        /// <summary>
        /// Constructor to set the cards rank and suit
        /// </summary>
        public Card (Rank rank, Suit suit)
        {
            Rank = Enum.IsDefined(typeof(Rank), rank) ? rank : throw new ArgumentException(nameof(rank));
            Suit = Enum.IsDefined(typeof(Suit), suit) ? suit : throw new ArgumentException(nameof(suit));
        }

        /// <summary>
        /// Returns a string representation of the card
        /// </summary>
        public override string ToString()
        {
            return $"{(char)Suit}{(Value > 1 && Value < 11 ? Value.ToString() : Rank.ToString().Substring(0, 1))}";
        }
    }
}
