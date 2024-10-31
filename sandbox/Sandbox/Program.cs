using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.WriteLine("Bonjour Tout Le Monde.");

        string name; 

        Console.WriteLine("Please enter your name");
        name = Console.ReadLine();

        Console.WriteLine($"Your name is: {name}\n");

        // Console.WriteLine will move the cursor to the next line
        // Console.Write will keep the cursor on the same line
        // Console.ReadLine will read the line
        // Console.Read will read a single character at a time
        // Parse converts string into integer 
        Console.Write("Enter Age: ");
        string userInput = Console.ReadLine();
        int age = int.Parse(userInput);

        Console.WriteLine($"Your age is : {age}");

        int x = 10;

        if (x > 15)  // Becareful about where you place semicolon
        {
            Console.WriteLine("Hey Bob");
        }

    }
}
