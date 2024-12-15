


using System.Data;
using System.Reflection.Metadata;

abstract class User
{
    private string userID;
    private string name;
    private string address;
    private string membership;


    private DateTime dateBorrowed; // Date Borrowed
    private DateTime dateReturned; // Date Returned
    private DateTime dueDate; // Due Date


    public User(string userID, string name, string address, string membership)
    {
        this.userID = userID;
        this.name = name;
        this.address = address;
        this.membership = membership;
    }
    

    // Getters and Setters
    public string GetUserID() => userID;
    public void SetUserID(string id) => userID = id;

    public string GetName() => name;
    public void SetName(string name) => this.name = name;

    public string GetAddress() => address;
    public void SetAddress(string address) => this.address = address;

    public string GetMembership() => membership;
    public void SetMembership(string membership) => this.membership = membership;

    // Date Borrowed
    public void DateBorrowed()
    {
        dateBorrowed = DateTime.Now;
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

        dueDate = currentDate.AddDays(DaysToBorrow());
        Console.WriteLine($"Due Date: {dueDate}");

        if (dueDate < currentDate)
        {
            TimeSpan daysLate = dueDate - currentDate;
 
            Console.WriteLine($"{name} is {daysLate} day(s) late.");
        }
        else
        {
            Console.WriteLine($"{name} is within the borrowing period.");
        }
    }

    public abstract int DaysToBorrow();
    
}