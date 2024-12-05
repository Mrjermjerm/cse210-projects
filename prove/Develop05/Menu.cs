

using System.ComponentModel;
using System.Numerics;
using System.Xml;
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
}
