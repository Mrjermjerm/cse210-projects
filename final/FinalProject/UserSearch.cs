

class UserSearch
{

    private List<User> foundUsers = new List<User>();
    private List<User> allUsers = new List<User>();

    public UserSearch()
    {
        Library library = new Library();
        library.ReadUsersFromFile("Users.txt");
        allUsers = library.GetUsers();
    }

    public void Search()
    { 
        string choice;
        
        do 
        {
            Console.WriteLine("\nHow do you want to search?");
            Console.WriteLine("  1. ID");
            Console.WriteLine("  2. Name");
            Console.WriteLine("  3. Address");
            Console.Write($"User Input: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the User ID: ");
                string userID = Console.ReadLine();
                Console.WriteLine(); // Space
                SearchByUserID(userID);
            }
            else if (choice == "2")
            {
                Console.Write("Enter the User's name: ");
                string name = Console.ReadLine();
                Console.WriteLine(); // Space
                SearchByName(name);
            }
            else if (choice == "3")
            {
                Console.Write("Enter the User's address: ");
                string address = Console.ReadLine();
                Console.WriteLine(); // Space 
                SearchByAddress(address);
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                break;
            }
        } while (choice != "0");        
    }
    
    // Search by User ID
    public void SearchByUserID(string userID)
    {
        foundUsers.Clear(); // Clear previous search results

        foreach (var user in allUsers)
        {
            if (user.GetAddress() == userID)
            {
                foundUsers.Add(user);
            }
        }
        DisplaySearchResults("User ID", userID);
    }

    // Search by Name
    public void SearchByName(string name)
    {
        foundUsers.Clear(); // Clear previous search results

        foreach (var user in allUsers)
        {
            if (user.GetAddress() == name)
            {
                foundUsers.Add(user);
            }
        }
        DisplaySearchResults("User Name", name);
    }

    // Search by Address
    public void SearchByAddress(string address)
    {
        foundUsers.Clear(); // Clear previous search results

        foreach (var user in allUsers)
        {
            if (user.GetAddress() == address)
            {
                foundUsers.Add(user);
            }
        }
        DisplaySearchResults("User Address", address);
    }

    // Display search results
    private void DisplaySearchResults(string searchType, string searchResult)
    {
        if (foundUsers.Count == 0)
        {
            Console.WriteLine($"No books forund for {searchType}:  {searchResult}");
        }
        else 
        {
            Console.WriteLine($"Books found for {searchType}:  {searchResult}");
            foreach (var user in foundUsers)
            {
                Console.WriteLine($"- {user.GetUserID()} by {user.GetName()} (ISBN: {user.GetAddress()})");
            }
        }
    }

    
}