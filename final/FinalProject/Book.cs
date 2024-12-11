

class Book
{

    private string _title;   
    private string _author;
    private string _isbn;
    private bool _status;
    

    public Book(string title, string author, string isbn, bool status)
    {
        _title = title;
        _author = author;
        _isbn = isbn;
        _status = status;
    }

    // Title
    public string GetTitle()
    {
        return _title;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }

    // Author
    public string GetAuthor()
    {
        return _author;
    }
    public void SetAuthor(string author)
    {
        _author = author;
    }

    // ISBN
    public string GetISBN()
    {
        return _isbn;
    }
    public void SetISBN(string isbn)
    {
        _isbn = isbn;
    }

    // Status
    public bool GetStatus()
    {
        return _status;
    }
    public void SetStatus(bool status)
    {
        _status = status;
    }
}