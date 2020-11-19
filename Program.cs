using System;

namespace examination3
{

    /// <summary>
    /// Initializing a game of Draw 21
    /// </summary>
    class Program
    {
        /// <summary>
        /// The starting point of the program.
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("1. Choose amount of players between 1-7");
                Console.WriteLine("Enter choice: ");

                int number;
                if(Int32.TryParse(Console.ReadLine(), out number))
                {
                    Console.Clear();
                    Gameboard game1 = new Gameboard(number);
                    game1.StartGame();
                }
                else
                {
                    Console.WriteLine("You have to write an integer.");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
