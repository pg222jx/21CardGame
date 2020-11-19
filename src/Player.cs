using System;
using System.Collections.Generic;
using System.Linq;

namespace examination3
{
    /// <summary>
    /// Representing a player
    /// </summary>
    class Player
    {
        /// <summary>
        /// Representing the players hand of cards
        /// </summary>
        private List<Card> _hand  = new List<Card>();

        /// <summary>
        /// The value in numbers of the players hand
        /// </summary>
        private int _handValue;

        /// <summary>
        /// The value the player will be satisfied with when reached
        /// </summary>
        private int _limit;

        /// <summary>
        /// The players name.
        /// </summary>
        private string _name;

        /// <summary>
        /// A readonly property to see the players hand
        /// </summary>
        public IReadOnlyList<Card> Hand => _hand.AsReadOnly();

        /// <summary>
        /// Property to calculate the players handvalue
        /// </summary>
        public int HandValue
        {
            get
            {
                _handValue = _hand.Sum(card => card.Value);
                int aces = 0;

                foreach(Card card in _hand)
                {
                    if (card.Value == 14)
                    {
                        aces += 1;
                    }
                }
                while (_handValue > 21 && aces > 0)
                {
                    _handValue -= 13;
                    aces -= 1;
                }
                return _handValue;
            }
        }

        /// <summary>
        /// Property to get and set the players limit
        /// </summary>
        public int Limit 
        {
             get => _limit;
             private set
             {
                 if (value < 1 || value > 21)
                 {
                     throw new ArgumentOutOfRangeException($"{nameof(value)} is not a number between 1 and 21.");
                 } 
                 else
                 {
                     _limit = value;
                 }
             }
        }

        /// <summary>
        /// Property to get and set the players name
        /// </summary>
        public string Name 
        {
             get => _name;
             private set
             {
                 if (value.Trim().Length <= 0)
                 {
                     throw new ArgumentOutOfRangeException("Nickname needs to be over 0 characters.");
                 } 
                 else
                 {
                     _name = value;
                 }
             }
        }

        /// <summary>
        /// Checks if player has reached limit
        /// </summary>
        public bool WantsCard 
        {
            get
            {
                if (HandValue < Limit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// Constuctor to set the players limit and name
        /// </summary>
        public Player(int limit = 10, string name = "Player")
        {
            Limit = limit;
            Name = name;
        }

        /// <summary>
        /// Method to clear the players hand of cards
        /// </summary>
        public void ClearHand()
        {
            _hand.Clear();
        }

        /// <summary>
        /// Adds a card to the players hand
        /// </summary>
        public void DrawCard(Card card)
        {
            _hand.Add(card);
        }
    }
}
