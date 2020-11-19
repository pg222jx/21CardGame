using System;
using System.Collections.Generic;
using System.Linq;

namespace examination3
{
    /// <summary>
    /// Class representing the dealer inheriting from the player class
    /// </summary>
    class Dealer : Player
    {
        /// <summary>
        /// A new list to store the deck in
        /// </summary>
        private List<Card> _deck;

        /// <summary>
        /// The initial deck
        /// </summary>
        private Deck _deckOfCards = new Deck();

        /// <summary>
        /// Representing the trashpile
        /// </summary>
        private List<Card> _trashPile = new List<Card>();

        /// <summary>
        /// Constructor setting the limit and name of the dealer
        /// inheriting from player
        /// </summary>
        public Dealer (int limit = 10, string name = "Dealer") : base(limit, name) {}

        /// <summary>
        /// Takes card from deck
        /// </summary>
        public Card DealCard()
        {
            if (_deck.Count <= 1)
            {
                foreach (Card card in _trashPile)
                {
                    _deck.Add(card);
                }
                
                _trashPile.Clear();                
                Shuffle();
            }

            Card drawnCard = _deck[0];
            _deck.Remove(drawnCard);
            return drawnCard;
        }

        /// <summary>
        /// Creates a new shuffled deck
        /// </summary>
        public void GetShuffledDeck()
        {
            _deckOfCards.CreateDeck();
            _deck = new List<Card>(_deckOfCards.DeckOfCards);
            Shuffle();
        }
        
        /// <summary>
        /// Shuffles the deck using fisher yates method
        /// </summary>
        private void Shuffle()
        {
            Random random = new Random();
            var cardCount = _deck.Count();
            Card tempValue;
            int randomIndex;

            while (cardCount != 0)
            {
                randomIndex = random.Next(cardCount);
                cardCount -= 1;
                tempValue = _deck[cardCount];
                _deck[cardCount] = _deck[randomIndex];
                _deck[randomIndex] = tempValue;
            }
        }

        /// <summary>
        /// Adds all cards in hand to the trashpile
        /// </summary>
        public void ThrowCards(IEnumerable<Card> hand)
        {
            foreach(Card card in hand)
            {
                _trashPile.Add(card);
            }
        }
    }
}
