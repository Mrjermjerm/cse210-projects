using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number_entered = -1;
        
        while (number_entered != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            number_entered = int.Parse(Console.ReadLine());
             
            if(number_entered != 0)
            {
                numbers.Add(number_entered);
            }
        }
        
        // int sum = numbers.Sum();
        // double average = numbers.Average();
        // int maxNumber = numbers.Max();

        int sum = 0;
        int totalAmountOfNumbers = 0;
        double averageNumber = 0;
        int lowestPositiveNumber = numbers[0];
        int maxNumber = numbers[0];

        foreach(int number in numbers)
        {
            sum += number;
            totalAmountOfNumbers++;
            averageNumber = sum / totalAmountOfNumbers;

            if(number != 0)
            {
                if(number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            if(number !> 0)
            {
                if(number < lowestPositiveNumber)
                {
                    lowestPositiveNumber = number;
                }
            }
        }

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {averageNumber}");
        Console.WriteLine($"The max number is {maxNumber}");
        Console.WriteLine($"The lowest positive number is {lowestPositiveNumber}");

        numbers.Sort();

        Console.WriteLine($"The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number}");
        }
        
    }
}