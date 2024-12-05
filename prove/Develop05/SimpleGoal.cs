

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    // Implement the Display method for SimpleGoal
    public override void Display()
    {
        Console.WriteLine($"[ ] ~ {Name} ~ ({Description})");
    }
}


