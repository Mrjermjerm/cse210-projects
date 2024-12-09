

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { 
    }

    
    public override void Display()
    {
       
        Console.WriteLine($"[ ] ~ {_name} ~ ({_description})");
    }

    
    public override void MarkComplete(ref double userPoints) 
    {
       
        userPoints += _points;  
        Console.WriteLine($"Goal '{_name}' marked as complete again! You earned {_points} points.");
    }
}