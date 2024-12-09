
public class ChecklistGoal : Goal
{
    public int _completed { get; set; }
    public int _total { get; set; }
    public int _pointsPerTask { get; set; }
    public int _bonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int total, int pointsPerTask, int bonusPoints)
        : base(name, description, points)
    {
        _total = total;
        _completed = 0;
        _pointsPerTask = pointsPerTask;
        _bonusPoints = bonusPoints;
    }

 
    public override void Display()
    {
        string completionStatus = (_completed >= _total) ? "[X]" : "[ ]";
        Console.WriteLine($"{completionStatus} ~ {_name} ~ ({_description}) ~ {_completed}/{_total} completed");
    }

   
    public override void MarkComplete(ref double userPoints)  
    {
        if (_completed < _total)
        {
            _completed++; 
            userPoints += _pointsPerTask; 
            Console.WriteLine($"You completed one task for '{_name}' goal! You gained {_pointsPerTask} points.");

            if (_completed == _total) 
            {
                userPoints += _bonusPoints;  
                Console.WriteLine($"Congratulations! You've fully completed '{_name}' goal. You earned a bonus of {_bonusPoints} points.");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' is already fully completed!");
        }
    }
}