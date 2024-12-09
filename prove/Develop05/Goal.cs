public abstract class Goal
{
    public string _name { get; set; }
    public string _description { get; set; }
    public int _points { get; set; }
    public bool _isCompleted { get; set; }  

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;  
    }

    public abstract void Display();

    public virtual void MarkComplete(ref double userPoints) 
    {
        _isCompleted = true;
        userPoints += _points;  
    }

    public string GetCompletionStatus()
    {
        return _isCompleted ? "[X]" : "[ ]"; 
    }
}