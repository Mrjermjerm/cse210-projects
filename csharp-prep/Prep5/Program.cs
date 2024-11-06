using System;
using System.Xml.XPath;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine($"Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write($"Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write($"Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareResult(int favoriteNumber)
    {
        int square = favoriteNumber * favoriteNumber;
        return square;
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int result = SquareResult(favoriteNumber);

        Console.WriteLine($"{username}, the square of your number is {result}");
        
    }
}