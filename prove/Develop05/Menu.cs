
public class Menu
{
    private double _points;  
    private CreateGoals _createGoals;

    public Menu(double points)
    {
        _points = points;
        _createGoals = new CreateGoals();
    }

    public void DisplayMenu()
    {
        bool userChoice = true;

        while (userChoice)
        {
            Console.WriteLine($"You have {_points} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                _createGoals.DisplayTypeOfGoals();  
            }
            else if (choice == "2")
            {
                _createGoals.ShowGoals();  
            }
            else if (choice == "3")
            {
                SaveGoalsToFile();
            }
            else if (choice == "4")
            {
                LoadGoalsFromFile();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye");
                userChoice = false;
            }
            else
            {
                Console.WriteLine("Invalid option\n");
            }
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Which goal would you like to mark as complete?");
        _createGoals.ShowGoals(); 

        if (_createGoals.GetGoalList().Count == 0)
        {
            Console.WriteLine("No goals to mark as complete.");
            return;
        }

        Console.Write("Enter the number of the goal to mark as complete: ");
        int goalNumber;
        bool isValid = int.TryParse(Console.ReadLine(), out goalNumber);

        if (isValid && goalNumber >= 1 && goalNumber <= _createGoals.GetGoalList().Count)
        {
            Goal selectedGoal = _createGoals.GetGoalList()[goalNumber - 1]; 
            selectedGoal.MarkComplete(ref _points); 
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    private void SaveGoalsToFile()
    {
        string goalsFile = "myGoals.txt";

        using (StreamWriter outputFile = new StreamWriter(goalsFile))
        {
            foreach (var goal in _createGoals.GetGoalList())
            {
                string goalType = goal.GetType().Name;
                outputFile.WriteLine($"{goalType}~{goal._name}~{goal._description}~{goal._points}~{goal.GetCompletionStatus()}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    outputFile.WriteLine($"{checklistGoal._total}~{checklistGoal._completed}~{checklistGoal._pointsPerTask}~{checklistGoal._bonusPoints}");  
                }
            }
        }
    }

    private void LoadGoalsFromFile()
    {
        string goalsFile = "myGoals.txt";
        string[] lines = File.ReadAllLines(goalsFile);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("~");

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            string status = parts[4];

            Goal goal = null;

            if (goalType == "SimpleGoal")
            {
                goal = new SimpleGoal(name, description, points);
            }
            else if (goalType == "EternalGoal")
            {
                goal = new EternalGoal(name, description, points);
            }
            else if (goalType == "ChecklistGoal")
            {
                int totalTasks = int.Parse(parts[5]);
                int completedTasks = int.Parse(parts[6]);
                int pointsPerTask = int.Parse(parts[7]); 
                int bonusPoints = int.Parse(parts[8]);  
                goal = new ChecklistGoal(name, description, points, totalTasks, pointsPerTask, bonusPoints);
            }

            if (goal != null)
            {
                if (status == "[X]")
                {
                    goal.MarkComplete(ref _points);
                }
                _createGoals.GetGoalList().Add(goal);
            }
        }
    }
}