


using System.Xml.Serialization;

class Menu
{   
    private int activitiesDone = 0;

    private string Prompt()
    {
        Console.Clear();
        
        Console.WriteLine($"You have done {activitiesDone} activities.");

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
                Activities activities1 = new Activities("","","");
                Breathing breathing = new Breathing();

                Console.Write($"{breathing.WelcomeMessage()}\n\n{breathing.DescriptionMessage()}\n\n{activities1.PromptForTimeToWork()}");
                
                breathing.Time();
                activitiesDone++;
                break;

            case "2":
                Activities activities2 = new Activities("","","");
                Reflection reflection = new Reflection();

                Console.Write($"{reflection.WelcomeMessage()}\n\n{reflection.DescriptionMessage()}\n\n{activities2.PromptForTimeToWork()}");

                reflection.Time();
                activitiesDone++;
                break;

            case "3":
                Activities activities3 = new Activities("","","");
                Listing listing = new Listing();

                Console.Write($"{listing.WelcomeMessage()}\n\n{listing.DescriptionMessage()}\n\n{activities3.PromptForTimeToWork()}");

                listing.Time();
                activitiesDone++;
                Thread.Sleep(1000);
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
       string userChoice;
       do
       {
            userChoice = Prompt();
       } while(userChoice != "4");
    }
}