


class Scripture
{
    private List<string> _verses = new List<string>();

    public Scripture()
    {
        _verses.Add(" For God so loved the world that he gave his only begotten Son, that whoever believes in him should not perish but have everlasting life.");
        // _verses.Add(" Trust in the Lord with all thine heart; and lean not unto thine own understanding.");
        // _verses.Add("  In all thy ways acknowledge him, and he shall direct thy paths.");
    }

    public List<string> GetVerse()
    {
        return _verses;
    }
}