

using System.IO.Pipes;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Principal;

class Library
{

    private List<Book> _books = new List<Book>();
    private List<User> _users = new List<User>(); 

    // User Interface 
    public void Main()
    {
        string choice;

        do 
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to Jeremy's Library Management.\n\nPlease select one of the following:");
            Console.WriteLine("  0. To Exit \n  1. Manage Books \n  2. Manage Users");
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
        Console.Write("Enter the User information.\nUser ID: ");
        user.SetUserID(Console.ReadLine());

        Console.Write("Name: ");
        user.SetName(Console.ReadLine());

        Console.Write("Address: ");
        user.SetAddress(Console.ReadLine());

        Console.Write("Membership: \n1.  Basic \n2.  Preimium ");
        string choice = Console.ReadLine();
         
        if (choice == "1")
        {
            user.SetMembership("Basic");  // You can store the membership type as a string
        }
        else if (choice == "2")
        {
            user.SetMembership("Premium");
        }

        _users.Add(user);
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

            User newUser= new User("","","","");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddUser(newUser);
                SaveUsersToFile("Users.txt");
            }
            else if (choice == "2")
            {
                Console.Clear();
                
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

            Book newBook = new Book("","","", true);
            choice = Console.ReadLine();

            if (choice == "1")
            {
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
                    writer.WriteLine($"{user.GetUserID()},{user.GetName()},{user.GetAddress()}");
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
                        User user = new User("","","","");
                        Library library = new Library();
                        user.SetUserID(details[0]);
                        user.SetName(details[1]);
                        user.SetAddress(details[2]);
                        user.SetMembership(details[3]);
                        _users.Add(user);  // Add the book to the list
                    }
                }

                Console.WriteLine("Users by Name.\n");
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




}