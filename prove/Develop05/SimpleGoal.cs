
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) 
    { 
    }

    public override void Display()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} ~ {_name} ~ ({_description})");
    }

    public override void MarkComplete(ref double userPoints) 
    {
        base.MarkComplete(ref userPoints);  
    }
}


