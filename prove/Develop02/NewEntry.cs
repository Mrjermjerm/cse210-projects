

class NewEntry
{
    public string DisplayNewEntry()
    {
        Prompt prompt = new Prompt();
        return prompt.RandomPrompt();
    }
    public void DisplayCarrot()
    {
        Console.Write($"> ");
    }
}