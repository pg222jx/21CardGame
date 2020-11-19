using System;
using System.Collections.Generic;
using System.Linq;

namespace examination3
{
    /// <summary>
    /// Representing a deck
    /// </summary>
    class Deck
    {
        /// <summary>
        /// Representing a deck of cards
        /// </summary>
        private List<Card> _deckOfCards;

        /// <summary>
        /// Readonly property to see the deck
        /// </summary>
        public IReadOnlyList<Card> DeckOfCards => _deckOfCards.AsReadOnly();

        /// <summary>
        /// Creates a new deck
        /// </summary>
        public void CreateDeck()
        {
            _deckOfCards = new List<Card>();
            

            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _deckOfCards.Add(new Card(rank, suit));
                }

            }
        }
    }
}
