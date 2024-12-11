


using System.IO.Pipes;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Principal;

class Library
{

    private List<Book> _books = new List<Book>();

    // User Interface
    public void Main()
    {
        string choice;

        do 
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to Jeremy's Library Management. \nPlease select one of the following.");
            Console.WriteLine("0. To Exit \n1. Manage Books");
            Console.Write("\nUser Input: ");

            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                BookManagement();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else 
            {
                Console.WriteLine("Invalid option");
            }
        } while (choice != "0");
    }

    // Check Books Available
    public void BookAvailability()
    {
        ReadBooksFromFile("Books.txt");
        
        foreach (var book in _books)
        {
            if ( book.GetStatus() == true)
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

    // Book Management 
    public void BookManagement()
    {
        string choice;

        do
        {
            Console.WriteLine($"\nWelcome to Book Managment");
            Console.WriteLine($"0. To Exit \n1. Add Book\n2. Check Book Availability");
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
                BookAvailability();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
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
            Console.WriteLine("Books have been added to the library.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the books: {ex.Message}");
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
}