

class Entry
{
    private DateTime _dateTime = new DateTime();

    private string _entry;

    // public Entry(DateTime _dateTime, string _entry)
    // {
    //     this._dateTime = _dateTime;
    //     this._entry = _entry;
    // }

    
   
    public void DisplayEntry()
    {
        // Prompt prompt = new Prompt();

        // Console.WriteLine($"Date: {_dateTime} - Prompt: {prompt}");

        // Entry entry = new Entry(_dateTime, _entry);
        // Console.WriteLine($"{entry}");

        Prompt prompt = new Prompt(); 
        prompt.DisplayPrompt();

        Console.Write($"> ");
        _entry = Console.ReadLine();
        
        // Console.WriteLine($"Date: {_dateTime} - Prompt: {prompt}");
    }
}