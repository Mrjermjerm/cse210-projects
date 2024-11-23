

class ChooseScripture
{
    public ChooseScripture()
    {

    }

    public void Choice()
    {
        string choice;
        Console.WriteLine("Multi or single verse scripture?");
        Console.WriteLine("Please enter 1 for multi or 2 single");
        choice = Console.ReadLine();

        if (choice == "1")
        {
            Reference reference = new Reference("John", 3, 16);
            Console.Write(reference.GetScripture());
        }
        else if (choice == "2")
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            Console.Write(reference.GetMultiScripture());
        }
    }
}