

using System.Runtime.CompilerServices;

class Menu
{

    private int _choice;


    public void DisplayMenu()
    {
        Console.WriteLine($"1. Write");
        Console.WriteLine($"2. Display");
        Console.WriteLine($"3. Load");
        Console.WriteLine($"4. Save");
        Console.WriteLine($"5. Quit");

        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            Journal journal = new Journal();
            journal.DisplayJournal();
        }
        
    }
}