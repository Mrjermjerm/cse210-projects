

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    // Implement the Display method for EternalGoal
    public override void Display()
    {
        Console.WriteLine($"[ ] ~ {Name} ~ ({Description})");
    }
}