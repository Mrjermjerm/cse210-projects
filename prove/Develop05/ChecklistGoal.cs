

public class ChecklistGoal : Goal
{
    public int Completed { get; set; }
    public int Total { get; set; }

    public ChecklistGoal(string name, string description, int points, int total)
        : base(name, description, points)
    {
        Total = total;
        Completed = 0;
    }

    // Implement the Display method for ChecklistGoal
    public override void Display()
    {
        Console.WriteLine($"[ ] ~ {Name} ~ ({Description}) ~ Currently completed: {Completed}/{Total} )");
    }

    public void MarkComplete()
    {
        if (Completed < Total)
            Completed++;
    }
}