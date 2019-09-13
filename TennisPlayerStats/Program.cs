using System;

namespace TennisPlayerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
            } while (userInput != 4);
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Tennis Player Stats");
            Console.WriteLine();
            Console.WriteLine("1. List Tennis Player");
            Console.WriteLine("2. List a tennis player");
            Console.WriteLine("3. Delete a player");
            Console.WriteLine("4. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
