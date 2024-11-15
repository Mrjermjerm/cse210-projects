

using System.Runtime.CompilerServices;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.IO.Enumeration;

class Menu
{
    private string _entry;
    DateTime timeOfEntry = DateTime.Now;
    private List<Tuple<string, string, string>> _newEntry = new List<Tuple<string, string, string>>();
    // private string _journal = "myJournalEntrys.txt";

    public void DisplayMenu()
    {
        NewEntry journal = new  NewEntry();
        string prompt = journal.DisplayNewEntry();
        
        string date = timeOfEntry.ToShortDateString();
        string choice = "";
        
        while(choice != "6")
        {
            Choices options = new Choices();
            options.DisplayChoices();

            choice = Console.ReadLine();

            if (choice == "1")
            {
                prompt = journal.DisplayNewEntry();

                Console.WriteLine($"{prompt}");

                journal.DisplayCarrot();
                _entry = Console.ReadLine();
                
                // string randomPrompt = prompt.RandomPrompt();
                _newEntry.Add(new Tuple<string, string, string>(date, prompt, _entry));
            }

            else if (choice == "2")
            {   
                Console.WriteLine($"\n\tList of new entries: ");

                foreach (var entry in _newEntry)
                Console.WriteLine($"Date: {entry.Item1} - {entry.Item2}\n{entry.Item3}");
            }

            else if (choice == "3")
            {
                try
                {
                    string fileName = Console.ReadLine();
                    string[] loadEntries = File.ReadAllLines($"{fileName}");
                    Console.WriteLine("\n\tJournal Entries\n");
                    foreach (string entry in loadEntries)
                    {
                        Console.WriteLine(entry);
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine($"\n\tSorry, file dosn't exist");
                }
            }
            
            else if (choice == "4")
            {
                List<string> entriesTOSave = new List<string>();
                foreach (var entry in _newEntry)
                {
                    string formattedEntry =($"Date: {entry.Item1} - {entry.Item2}\n{entry.Item3}");
                    entriesTOSave.Add(formattedEntry);
                }
                Console.WriteLine($"\n\tEnter file to save to: ");
                string fileName = Console.ReadLine();

                try
                {
                    using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
                    {
                        foreach (var entry in entriesTOSave)
                        {
                            outputFile.WriteLine(entry);
                        }
                    }
                    Console.WriteLine($"\n\tJournel entries saved");
                    
                }
                catch (Exception error)
                {
                    Console.WriteLine($"An error occured while saving to {error.Message}");
                }
            }

            else if(choice == "5")
            {
                Console.WriteLine($"\n\tEnter File to be deleted: ");
                string fileName = Console.ReadLine();
                {
                    if (File.Exists(fileName))
                    {
                        
                        File.Delete(fileName);
                        Console.WriteLine($"File '{fileName}' has been deleted");
                    }

                    else
                    {
                        Console.WriteLine($"{fileName} doesn't exist ");
                    }
                }
            }

            else if (choice == "6")
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