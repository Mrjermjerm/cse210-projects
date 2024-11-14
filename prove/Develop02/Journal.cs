

using System.IO;

class Journal
{

    private string _journal = "myJournalEntrys.txt";


    public Journal()
    {
        // Entry entry = new Entry();
        // entry.DisplayEntry();
        
        // using (StreamWriter outputFile = new StreamWriter(_journal))
        // {
        //     outputFile.WriteLine(entry);
        // }
    }

    public void DisplayJournal()
    {
        Entry entry = new Entry();
        entry.DisplayEntry();
        
        using (StreamWriter outputFile = new StreamWriter(_journal))
        {
            outputFile.WriteLine(entry);
        }
    }
}