using System;
using System.Drawing;
using System.Security.Cryptography;

class Program
{
    static int AddNUmbers(int n1, int n2)
    {
        int total = n1 + n2;
        return total;
    }


    static void Main(string[] args)
    {

        // int total = AddNUmbers(20,30);
        // Console.WriteLine(total);

        int x = 10;
        int y = x++;
        Console.WriteLine($"{y}, {x}");

        int z = ++y;
        Console.WriteLine($"{z}, {y}");


        // Console.WriteLine("Hello Sandbox World!");
        // Console.WriteLine("Bonjour Tout Le Monde.");

        // string name; 

        // Console.WriteLine("Please enter your name");
        // name = Console.ReadLine();

        // Console.WriteLine($"Your name is: {name}\n");

        // // Console.WriteLine will move the cursor to the next line
        // // Console.Write will keep the cursor on the same line
        // // Console.ReadLine will read the line
        // // Console.Read will read a single character at a time
        // // Parse converts string into integer 
        // Console.Write("Enter Age: ");
        // string userInput = Console.ReadLine();
        // int age = int.Parse(userInput);

        // Console.WriteLine($"Your age is : {age}");

        // int x = 10;

        // if (x > 15)  // Becareful about where you place semicolon
        // {
        //     Console.WriteLine("Hey Bob");
        // }



        Console.WriteLine("Hey BOb");

        for(int i = 0; i < 11; i++) // To increment by another number is += # 
        {
            Console.WriteLine(i);
        }

        // int age = -1;

        // while(age < 0 || age > 120)
        // {
        //     Console.Write("Please enter your age: ");
        //     age = int.Parse(Console.ReadLine());
        //     Console.WriteLine($"Your age is: {age}");
        // }

        int age;

        do 
        {          
            Console.Write("Please enter your age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine($"Your age is: {age}");
        }while(age < 0 || age > 120);


        List <string> myColors = new List<string>();

        myColors.Add("Red");
        myColors.Add("Green");
        myColors.Add("Blue");


        foreach(string color in myColors)
        {
            Console.WriteLine(color);
        }

        
    }
}
