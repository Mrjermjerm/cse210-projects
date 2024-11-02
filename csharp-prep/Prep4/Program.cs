using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num = -1;

        while (num != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            num = int.Parse(Console.ReadLine());
            numbers.Add(num);
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();

        Console.WriteLine($"The sum is {sum}.");
        Console.WriteLine($"The aveage is {average}.");
        Console.WriteLine($"The largest number is {maxNumber}.");

        int? smallestPositive = null;
        foreach (var number in numbers)
        {
            if (number > 0)
            {
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }

        Console.WriteLine("Smallest positive number: " + (smallestPositive.HasValue ? smallestPositive.Value.ToString() : "None"));

        numbers.Sort();

        Console.WriteLine($"The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number}");
        }
        
    }
}