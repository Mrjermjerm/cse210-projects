

class NewEntry
{
    public void DisplayNewEntry()
    {
        Prompt prompt = new Prompt(); 
        prompt.DisplayPrompt();

        Console.Write($"> ");
    }
}