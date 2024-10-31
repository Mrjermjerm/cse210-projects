using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade in the class? ");
        string grade = Console.ReadLine();
        int x = int.Parse(grade);

        int sign = x % 10;
        string letter = "";
        string minus = "-";
        string plus = "+";


        // Letter Grade A
        if (x >= 90)
        {
            letter = "A";

            if (sign < 3) // A-
            {
                Console.WriteLine($"You have an {letter}{minus} in the class.");
            }
            
            else // A
            {
                Console.WriteLine($"You have an {letter} in the class.");
            }           
        }

        // Letter Grade B
        else if (x >= 80)
        {
            letter = "B";

            if (sign < 3) // B-
            {
                Console.WriteLine($"You have a {letter}{minus} in the class");
            }
            
            else if (sign >= 7) // B+
            {
                Console.WriteLine($"You have a {letter}{plus} in the class");
            }

            else // B
            {
                Console.WriteLine($"You have a {letter} in the class");
            }
        }

        // Letter Grade C
        else if (x >= 70)
        {
            letter = "C";
            if (sign < 3) // C-
            {
                Console.WriteLine($"You have a {letter}{minus} in the class");
            }
            
            else if (sign >= 7) // C+
            {
                Console.WriteLine($"You have a {letter}{plus} in the class");
            }

            else // C
            {
                Console.WriteLine($"You have a {letter} in the class");
            }
        }

        // Letter Grade D
        else if (x >= 60)
        {
            letter = "D";
            if (sign < 3) // D-
            {
                Console.WriteLine($"You have a {letter}{minus} in the class");
            }
            
            else if (sign >= 7) // D+
            {
                Console.WriteLine($"You have a {letter}{plus} in the class");
            }

            else // D
            {
                Console.WriteLine($"You have a {letter} in the class");
            }
        }

        // Letter Grade F
        else 
        {
            letter = "F";
            Console.WriteLine($"You have an {letter} in the class.");
        }

        // Passing Grade
        if (x >= 70)
        {
            Console.WriteLine("Congratulations on passing the class!");
        }
        // Failing Grade
        else 
        {
            Console.WriteLine("It was tough but don't give up. Try again, youv'e got this.");
        }


    }
}