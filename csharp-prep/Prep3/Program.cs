using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        string response;
        
        do
        {
            // Console.Write("What is the magic number? ");
            // int magicNumber = int.Parse(Console.ReadLine());

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11);

            int guess = -1;
            int numberOfGuesses = 0;

            while (number != guess)
            { 
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                ++numberOfGuesses;

                if (number > guess)
                {
                    Console.WriteLine("Higher");
                }

                else if (number < guess)
                {
                    Console.WriteLine("Lower");
                }

                else 
                {
                    Console.WriteLine("You guessed it");
                    Console.WriteLine($"You gessed {numberOfGuesses} times.");
                }
                
            }
        
            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();
        } while (response == "yes");
    }
}