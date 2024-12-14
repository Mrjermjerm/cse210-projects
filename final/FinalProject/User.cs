


using System.Data;
using System.Reflection.Metadata;

class User
{
    private string _userID; // User ID
    private string _name; // Name
    private string _address; // Address
     private string _membership;
    private DateTime dateBorrowed = DateTime.Now; // Date Borrowed
    private DateTime dateReturned; // Date Returned
    private DateTime dueDate; // Due Date
    
    
    public User(string userID, string name, string address, string membership)
    {
        _userID = userID;
        _name = name;
        _address = address;
        _membership = membership;
    }

    // Membership Type
    public string GetMembership() 
    { 
        return _membership; 
    }
    public void SetMembership(string membership) 
    { 
        _membership = membership; 
    }
    
    // User ID
    public string GetUserID()
    {
        return _userID;
    }
    public void SetUserID(string userID)
    {
        _userID = userID;
    }

    // User Name
    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }

    // User Address
    public string GetAddress()
    {
        return _address;
    }
    public void SetAddress(string address)
    {
        _address = address;
    }

    // Date Borrowed 
    public void DateBorrowed()
    {
        Console.WriteLine($"Date Borrowed: {dateBorrowed}");
    }

    // Dater Returned
    public void DateReturned()
    {
        dateReturned = DateTime.Now;
        Console.WriteLine($"Date Borrowed: {dateReturned}");
    }

    // BorrowLimit
    public void BorrowLimit()
    {
        DateTime currentDate = DateTime.Now;

        dueDate = currentDate.AddDays(DaysTOBorrow());
        Console.WriteLine($"Due Date: {dueDate}");

        if (dueDate > currentDate)
        {
            TimeSpan daysLate = dueDate - currentDate;
 
            Console.WriteLine($"{_name} is {daysLate}");
        }
    }

    public virtual int DaysTOBorrow()
    {
        return 0;
    }


    
}