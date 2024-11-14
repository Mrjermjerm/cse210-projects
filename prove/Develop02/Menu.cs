

using System.Runtime.CompilerServices;
using System.IO;

class Menu
{

    private string _entry;

    private List<string> _newEntry = new List<string>();

    private string _journal = "myJournalEntrys.txt";

    public void DisplayMenu()
    {

        string choice = "";
        
        while(choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine($"Please Select one of the following choices: ");
            Console.WriteLine($"1. Write");
            Console.WriteLine($"2. Display");
            Console.WriteLine($"3. Load");
            Console.WriteLine($"4. Save");
            Console.WriteLine($"5. Quit");
            Console.Write($"What would you like to do? ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                NewEntry journal = new  NewEntry();
                journal.DisplayNewEntry();

                _newEntry.Add(_entry = Console.ReadLine());
            }

            else if (choice == "2")
            {   
                Console.WriteLine($"\n\tList of new entries: ");

                foreach (string entry in _newEntry)
                Console.WriteLine(entry);
            }

            else if (choice == "3")
            {
                string[] loadEntries = File.ReadAllLines("myJournalEntrys.txt");
                Console.WriteLine("\n\tJournal Entries\n");
                foreach (string entry in loadEntries)
                {
                    Console.WriteLine(entry);
                }
            }
            
            else if (choice == "4")
            {
                File.WriteAllLines(_journal, _newEntry);
                Console.WriteLine($"\n\tJournel entries saved");
            }

            else if (choice == "5")
            {
                Console.WriteLine("\n\tGood bye");
            }

            else
            {
                Console.WriteLine($"\n\tSorry, please select one of the five choices");
            }
        }  
    }
}