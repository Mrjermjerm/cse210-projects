


using System.Dynamic;
using System.Xml.Serialization;
class Menu
{
    private Scripture _scripture;
    private Word _word;

    public Menu()
    {
        _scripture = new Scripture();
    }

    public void GetMenu()
    {
        string choice = "";

        while (choice != "quit")
        {
            Console.Clear();
            Console.WriteLine("Multi or single verse scripture?");
            Console.WriteLine("Please enter 1 for multi or 2 for single");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                ChooseScripture chooseScripture = new ChooseScripture();
                chooseScripture.Choice("multi");
                _scripture = chooseScripture.GetScripture(); 
                _word = new Word(_scripture.GetVerse()); 
                DisplayAndHideWords(chooseScripture);
            }
            else if (choice == "2")
            {
                ChooseScripture chooseScripture = new ChooseScripture();
                chooseScripture.Choice("single");
                _scripture = chooseScripture.GetScripture();
                _word = new Word(_scripture.GetVerse());
                DisplayAndHideWords(chooseScripture);
            }
            else
            {
                Console.WriteLine("Good bye");
            }
        }
    }

    private void DisplayAndHideWords(ChooseScripture chooseScripture)
    {
        string reference = chooseScripture.GetReference();
        Console.Clear();
        Console.WriteLine(reference);
        Console.WriteLine(string.Join(" ", _scripture.GetVerse()));

        while (true)
        {
            string userAction = Console.ReadLine(); 
            if (userAction == "")
            {
                Console.Clear();
                Console.WriteLine(reference);
                _word.GetReplaceWords(); 

                if (_word.AllWordsHidden())
                {
                    Console.WriteLine("All words hidden! Press enter to continue.");
                    Console.ReadLine(); 
                    break;
                }
            }
            else if (userAction == "quit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press enter to continue hiding words.");
            }
        }
    }
}