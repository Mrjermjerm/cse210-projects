


using System.Xml.Serialization;

class Menu
{

    private string Prompt()
    {
        Console.Clear();

        Console.WriteLine($"Menu Options:");
        Console.WriteLine($"\t1. Start breathing activity");
        Console.WriteLine($"\t2. Start reflecting activity");
        Console.WriteLine($"\t3. Start listing acitvity");
        Console.WriteLine($"\t4. Quit");
        Console.Write("Select a choice from the menu: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Activities activities = new Activities("","");
                Breathing breathing = new Breathing();

                Console.Write($"{breathing.WelcomeMessage()}\n\n{breathing.DescriptionMessage()}\n\n{activities.PromptForTimeToWork()}");
                
                breathing.Time();
                break;

            case "2":
                Console.WriteLine("You chose 2");
                break;

            case "3":
                Console.WriteLine("You chose 3");
                break;

            case "4":
                Console.WriteLine($"Good bye");
                break;

            default:
                Console.WriteLine("Invaild option");
                break;
        }
        return choice;
    }

    public void GetPrompt()
    {
       Menu menu = new Menu();
       menu.Prompt();
    }
}