

using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading.Channels;

class Prompt
{
    private List<string> _prompt = new List<string>();
    private Random random = new Random();

    public Prompt()
    {
        _prompt.Add("Who was the most interesting person I interacted with today?");
        _prompt.Add("What was the best part of my day?");
        _prompt.Add("How did I see the hand of the Lord in my life today?");
        _prompt.Add("What was the strongest emotion I felt today?");
        _prompt.Add("If I had one thing I could do over today, what would it be?");
    }
    
    public string RandomPrompt()
    {
        return _prompt[random.Next(_prompt.Count)];
    } 

    public void DisplayPrompt()
    {
        Prompt prompt = new Prompt();
        Console.WriteLine(prompt.RandomPrompt());
    }
}