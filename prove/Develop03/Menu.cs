


using System.Dynamic;
using System.Xml.Serialization;

class Menu
{
    private Scripture _scripture;
    private Word _word;

    public Menu()
    {
        _scripture = new Scripture();
        _word = new Word(_scripture.GetVerse());
    }

    public void GetMenu()
    {        
        string choice = "";
        
        while(choice != "quit")
        {
            Reference reference = new Reference("John", 3, 16);
            Console.Clear();
            Console.Write(reference.GetScripture());

            Console.WriteLine(string.Join(" ",_scripture.GetVerse()));
            choice = Console.ReadLine();
            
            if(choice == "")
            {
                Console.Clear();
                Console.Write(reference.GetScripture());
                _word.GetReplaceWords();

                if (_word.AllWordsHidden())
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }
    }
}