using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());
        
        Console.WriteLine("\n"); // Space

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez","Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Console.WriteLine("\n");

        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War");
        Console.WriteLine(writingAssignment.GetWtritingInformation());
    }
}