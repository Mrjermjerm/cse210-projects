


class Scripture
{
    private List<string> _verses;

    public Scripture()
    {
        _verses = new List<string>
        {
            "For God so loved the world that he gave his only begotten Son, that whoever believes in him should not perish but have everlasting life.",
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding.",
            "In all thy ways acknowledge him, and he shall direct thy paths."
        };
    }

     public Scripture(List<string> verses)
    {
        _verses = verses;
    }
    
    public List<string> GetVerse()
    {
        return _verses;
    }
}