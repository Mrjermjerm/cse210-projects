

public class CreateGoals
{
    private List<Goal> _goals = new List<Goal>();

    public List<Goal> GetGoalList()
    {
        return _goals;
    }

    public void ShowGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.\n");
            return;
        }

        Console.WriteLine("Here are your goals:\n");
        for (int i = 0; i < _goals.Count; i++)  
        {
            Console.WriteLine($"{i + 1}. ");  
            _goals[i].Display(); 
        }
        Console.WriteLine();
    }

    
    public void DisplayTypeOfGoals()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();
        Goal newGoal = null; 

        switch (choice)
        {
            case "1":
                newGoal = CreateSimpleGoal();
                break;
            case "2":
                newGoal = CreateEternalGoal();
                break;
            case "3":
                newGoal = CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid option\n");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!\n");
    }

    private Goal CreateSimpleGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        return new SimpleGoal(name, description, points);  // Return a new SimpleGoal instance
    }

    private Goal CreateEternalGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        return new EternalGoal(name, description, points);  // Return a new EternalGoal instance
    }

    private Goal CreateChecklistGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("Enter total tasks: ");
        int total = int.Parse(Console.ReadLine());

        Console.Write("Enter points per task: ");
        int pointsPerTask = int.Parse(Console.ReadLine());

        Console.Write("Enter bonus points for completing the goal: ");
        int bonusPoints = int.Parse(Console.ReadLine());

        return new ChecklistGoal(name, description, points, total, pointsPerTask, bonusPoints);  // Return a new ChecklistGoal instance
    }
}