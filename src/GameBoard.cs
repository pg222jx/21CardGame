using System;
using System.Collections.Generic;
using System.Linq;

namespace examination3
{

    /// <summary>
    /// Class representing the gameboard
    /// </summary>
    class Gameboard
    {
        /// <summary>
        /// The games dealer
        /// </summary>
        private Dealer dealer = new Dealer();

        /// <summary>
        /// All players
        /// </summary>
        private List<Player> players = new List<Player>();

        /// <summary>
        /// Amount of players
        /// </summary>
        private int _nrOfPlayers;

        /// <summary>
        /// Property get and set the amount of players playing
        /// </summary>
        public int NrOfPlayers
        {
            get => _nrOfPlayers;
            private set
            {
                if (value > 7)
                {
                    throw new ArgumentOutOfRangeException("There can't be more than 7 players at the table.");
                }
                else if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("There must be 1 or more players to play the game.");
                }
                _nrOfPlayers = value;
            }
        }

        /// <summary>
        /// Constructor to set amount of players
        /// </summary>
        public Gameboard(int nrOfPlayers = 1)
        {
            NrOfPlayers = nrOfPlayers;
        }

        /// <summary>
        /// Create players and sets their limit and name
        /// </summary>
        private void CreatePlayers()
        {
            for (int i = 1; i < _nrOfPlayers + 1; i++)
            {
                Random random = new Random();
                int limit = random.Next(8, 16);
                string id = ($"Player #{i}");
                Player player = new Player(limit, id);
                players.Add(player);
            }
        }

        /// <summary>
        /// Gives a card to all players
        /// </summary>
        private void GiveFirstCard()
        {
            foreach (Player player in players)
            {
                Card givenCard = dealer.DealCard();
                player.DrawCard(givenCard);
            }
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        public void StartGame()
        {
            dealer.GetShuffledDeck();
            CreatePlayers();
            GiveFirstCard();

            foreach (var player in players)
            {
                Play(player);
            }
        }

        /// <summary>
        /// Plays a game of Draw 21
        /// </summary>
        private void Play(Player player)
        {
            Card givenCard;

            do
            {
                givenCard = dealer.DealCard();
                player.DrawCard(givenCard);
            } while (player.WantsCard && player.Hand.Count < 5);

            if (player.HandValue < 21)
            {
                while (dealer.WantsCard && dealer.Hand.Count < 5) 
                {
                    givenCard = dealer.DealCard();
                    dealer.DrawCard(givenCard);
                }
            }
            PrintResult(player);
        }

        /// <summary>
        /// Print the reslut to the console
        /// </summary>
        private void PrintResult(Player player)
        {

            Console.Write($"{player.Name}: ");

            foreach (Card card in player.Hand)
            {
                Console.Write(card + " ");
            }

            Console.Write(player.HandValue > 21 ? $" ({player.HandValue}) BUSTED! \n" : $" ({player.HandValue}) \n");

            Console.Write($"{dealer.Name}: ");
            if (dealer.Hand.Count != 0)
            {
                foreach (Card card in dealer.Hand)
                {
                    Console.Write(card + " ");
                }
                Console.Write(dealer.HandValue > 21 ? $" ({dealer.HandValue}) BUSTED! \n" : $" ({dealer.HandValue}) \n");
            }
            else
            {
                Console.Write("- \n");
            }

            // Check Winner
            
            if (player.HandValue > dealer.HandValue && player.HandValue <= 21 ||
                player.Hand.Count() == 5 && player.HandValue <= 21 ||
                player.HandValue < 21 && dealer.HandValue > 21)
            {
                Console.WriteLine("Player wins! \n");
            }
            else
            {
                Console.WriteLine("Dealer wins! \n");
            }

            dealer.ThrowCards(player.Hand);
            dealer.ThrowCards(dealer.Hand);

            player.ClearHand();
            dealer.ClearHand();
        }
    }
}
