

using System.IO.Pipes;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Transactions;

class Library
{

    private List<Book> _books = new List<Book>();
    private List<User> _users = new List<User>(); 
    private List<Transaction> _transactions = new List<Transaction>();

    // User Interface 
    public void Main()
    {
        string choice;

        do 
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to Jeremy's Library Management.\n\nPlease select one of the following:");
            Console.WriteLine("  0. To Exit \n  1. Manage Books \n  2. Manage Users \n  3. Manage Transactions");
            Console.Write("User Input: ");

            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                BookManagement();
            }
            else if (choice == "2")
            {
                Console.Clear();
                UserManagement();
            }
            else if (choice == "3")
            {
                Console.Clear();
                TransactionManagement();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                break;
            }
            else 
            {
                Console.WriteLine("Invalid option");
            }
        } while (choice != "0");
    }

    // Method for getting list of books
    public List<Book> GetBooks()
    {   
        return _books;
    }

    public List<User> GetUsers()
    {
        return _users;
    }

    // Check Books Available
    public void BookAvailability()
    {
        ReadBooksFromFile("Books.txt");
        
        foreach (var book in _books)
        {
            if ( book.GetStatus())
            {
                Console.WriteLine($"Title: {book.GetTitle()}");
            }
        }
    }

    // Add Books
    public void AddBook(Book book)
    {
        Console.Write("Enter the books information.\nBooks Title: ");
        book.SetTitle(Console.ReadLine());

        Console.Write("Author: ");
        book.SetAuthor(Console.ReadLine());

        Console.Write("ISBN: ");
        book.SetISBN(Console.ReadLine());

        Console.Write($"{book.GetTitle()} is now added to library.");
        book.SetStatus(true);
        _books.Add(book);
    }

    // Add User
    public void AddUser(User user)
    {
        _users.Add(user);
        SaveUsersToFile("Users.txt");
    }

    public void DeleteUser(string userID)
    {
        var userToRemove = _users.FirstOrDefault(u => u.GetUserID() == userID);
        
        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
            Console.WriteLine($"User with ID {userID} has been removed.");
            
            SaveUsersToFile("Users.txt");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // User Management
    public void UserManagement()
    {
        string choice;

        do
        {
            Console.WriteLine($"\nWelcome to User Managment:");
            Console.WriteLine($"  0. To Exit \n  1. Add User\n  2. Find User \n  3. Delete User");
            Console.Write("\nUser input: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nEnter details for the new user:");

                // Get UserID
                Console.Write("User ID: ");
                string userID = Console.ReadLine();

                // Get Name
                Console.Write("Name: ");
                string name = Console.ReadLine();

                // Get Address
                Console.Write("Address: ");
                string address = Console.ReadLine();

                // Get Membership Type
                Console.Write("Membership Type (1. Basic, 2. Premium): ");
                string membershipType = Console.ReadLine();


                User newUser;
                if (membershipType == "1")
                {
                    newUser = new BasicMember(userID, name, address, "Basic");
                }
                else
                {
                    newUser = new PremiumMember(userID, name, address, "Premium");
                }
                AddUser(newUser); // Save user to file and to list

            }
            else if (choice == "2")
            {
                Console.Clear();
                UserSearch userSearch = new UserSearch();
                userSearch.Search();                
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.Write("Enter User ID to delete: ");
                string userID = Console.ReadLine();
                DeleteUser(userID);
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                break;
            }
            else 
            {
                Console.WriteLine("Invalid option");
            }
        } while (choice != "0");
    }

    // Book Management 
    public void BookManagement()
    {
        string choice;

        do
        {
            Console.WriteLine($"\nWelcome to Book Managment:");
            Console.WriteLine($"  0. To Exit \n  1. Add Book\n  2. Check Book Availability \n  3. Search Book");
            Console.Write("\nUser input: ");

            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Book newBook = new Book("","","", true);
                AddBook(newBook);
                SaveBooksToFile("Books.txt");
            }
            else if (choice == "2")
            {
                Console.Clear();
                BookAvailability();
            }
            else if (choice == "3")
            {
                Console.Clear();
                BookSearch bookSearch = new BookSearch();
                bookSearch.Search();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                break;
            }
            else 
            {
                Console.WriteLine("Invalid option");
            }
        } while (choice != "0");
    }

    // Transaction Details
    public void TransactionManagement()
    {

        string choice;

        do
        {
            Console.WriteLine("\nWelcome to Transactions: ");
            Console.WriteLine($"  0. To Exit \n  1. Check out Books \n  2. Returns \n  3. Borrowed ");
            Console.Write("\nUser input: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Check Out\n");
                Console.Write("Enter User ID: ");
                string userID = Console.ReadLine();
                Console.WriteLine(); // Space
                
                // Serch For Book ISBN
                Console.WriteLine("Enter Book ISBN: ");
                string bookISBN = Console.ReadLine();

                var book = _books.FirstOrDefault(b => b.GetISBN() == bookISBN && b.GetStatus()== true);

                if (book != null)
                {
                    book.SetStatus(false);

                    _transactions.Add(new Transaction(userID, bookISBN, "borrow"));

                    Console.WriteLine($"Book {book.GetTitle()} checked out by user {userID}.");
                }
                else
                {
                    Console.WriteLine("Book not available or not found.");
                }
            }
            else if (choice == "2")
            {
                // Return Book
                Console.WriteLine("Return Book\n");
                Console.Write("Enter User ID: ");
                string userID = Console.ReadLine();

                // Search for User by UserID (implement search functionality)
                Console.Write("Enter Book ISBN: ");
                string bookISBN = Console.ReadLine();

                var book = _books.FirstOrDefault(b => b.GetISBN() == bookISBN && b.GetStatus() == false); // Book must be borrowed

                if (book != null)
                {
                    // Change the book's status to available
                    book.SetStatus(true);

                    // Add return transaction to the transaction list
                    _transactions.Add(new Transaction(userID, bookISBN, "return"));

                    Console.WriteLine($"Book {book.GetTitle()} returned by user {userID}.");
                }
                else
                {
                    Console.WriteLine("Book not found or not borrowed.");
                }
            }
            else if (choice == "3")
            {
                // View Borrowed Books
                Console.WriteLine("\nBorrowed Books: ");
                foreach (var transaction in _transactions.Where(t => t.GetAction() == "borrow"))
                {
                    Console.WriteLine($"User: {transaction.GetUserID()}, Book ISBN: {transaction.GetISBN()}, Date: {transaction.GetMembership()}");
                }
            }
        } while (choice != "0");
    }


    // Save the books to Books.txt
    public void SaveBooksToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in _books)
                {
                    // Write each book's details to the file in a simple format
                    writer.WriteLine($"{book.GetTitle()},{book.GetAuthor()},{book.GetISBN()}");
                }
            }
            Console.WriteLine("Books has been added to the library.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the books: {ex.Message}");
        }
    }

    // Save the User to Users.txt
    public void SaveUsersToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var user in _users)
                {
                    // Write each book's details to the file in a simple format
                    writer.WriteLine($"{user.GetUserID()},{user.GetName()},{user.GetAddress()},{user.GetMembership()}");
                }
            }
            Console.WriteLine("User has been added to the library.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the user: {ex.Message}");
        }
    }

    // Read books from Books.txt
    public void ReadBooksFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] details = line.Split(',');

                    if (details.Length == 3)
                    {
                        Book book = new Book("","","",true);
                        book.SetTitle(details[0]);
                        book.SetAuthor(details[1]);
                        book.SetISBN(details[2]);
                        book.SetStatus(true); 
                        _books.Add(book);  // Add the book to the list
                    }
                }

                Console.WriteLine("Books by title.\n");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the books: {ex.Message}");
        }
    }    

    // Read user from Users.txt
    public void ReadUsersFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] details = line.Split(',');

                    if (details.Length == 4)
                    {
                        string userID = details[0].Trim();
                        string name = details[1].Trim();
                        string address = details[2].Trim();
                        string membershipType = details[3].Trim();

                        User user = null;
                        
                        // Determine user type based on the membership string
                        if (membershipType.Equals("Basic", StringComparison.OrdinalIgnoreCase))
                        {
                            user = new BasicMember(userID, name, address, "Basic");
                        }
                        else if (membershipType.Equals("Premium", StringComparison.OrdinalIgnoreCase))
                        {
                            user = new PremiumMember(userID, name, address, "Premium");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid membership type for user {userID}, defaulting to Basic.");
                            user = new BasicMember(userID, name, address, "Basic");
                        }

                        // Add the user to the list of users
                        _users.Add(user);
                        Console.WriteLine($"User {user.GetName()} has been loaded.");
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the users: {ex.Message}");
        }
    }



}