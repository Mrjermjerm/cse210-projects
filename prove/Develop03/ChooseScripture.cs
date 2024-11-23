

class ChooseScripture
{
    private string _reference;
    private Scripture _scripture;

    public ChooseScripture() { }

    public void Choice(string type)
    {
        if (type == "multi")
        {
            _scripture = new Scripture(new List<string>
            {
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding.",
                "In all thy ways acknowledge him, and he shall direct thy paths."
            });
            _reference = "Proverbs 3:5-6"; 
        }
        else if (type == "single")
        {
              _scripture = new Scripture(new List<string>
            {
                "For God so loved the world that he gave his only begotten Son, that whoever believes in him should not perish but have everlasting life."
            });
            _reference = "John 3:16";
        }
    }
    
    public string GetReference()
    {
        return _reference;
    }

    public Scripture GetScripture()
    {
        return _scripture;
    }
}