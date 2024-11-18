using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        
        Fraction fraction1 = new Fraction(6);
        Console.WriteLine($"{fraction1.GetTop()}/1");

        Fraction fraction2 = new Fraction(6, 7);
        Console.WriteLine($"{fraction2.GetTop()}/{fraction2.GetBottom()}");
    }
}