

class Transaction
{

    public string _userID;
    public string _bookISBN;
    public DateTime _transactionDate;
    public string _action; // Borrow or Return
    
    public Transaction(string userID, string bookISBN, string action)
    {
        _userID = userID;
        _bookISBN = bookISBN;
        _action = action;
        _transactionDate = DateTime.Now;
    }

    // Getters and Setters
    public string GetUserID() => _userID;
    public void SetUserID(string id) => _userID = id;

    public string GetISBN() => _bookISBN;
    public void SetISBN(string isbn) => this._bookISBN = isbn;

    public string GetAction() => _action;
    public void SetAction(string action) => this._action = action;

    public DateTime GetMembership() => _transactionDate;
    public void SetMembership(string transactionDate) => this._transactionDate = DateTime.Now;

    public void BorrowBook()
    {

    }

    public void ReturnBook()
    {
        
    }


    
}