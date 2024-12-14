

using System.Security.Cryptography.X509Certificates;

class BookSearch
{
    private List<Book> foundBooks = new List<Book>();
    private List<Book> allBooks = new List<Book>(); // Holds all Books to avoid re-reading file each time
    
    public BookSearch()
    {
        Library library = new Library();
        library.ReadBooksFromFile("Books.txt");
        allBooks = library.GetBooks();
    }

    public void Search()
    { 
        string choice;
        
        do 
        {
            Console.WriteLine("\nHow do you want to search?");
            Console.WriteLine("  1. Title");
            Console.WriteLine("  2. Author");
            Console.WriteLine("  3. ISBN");
            Console.Write($"User Input: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the title to search: ");
                string title = Console.ReadLine();
                Console.WriteLine(); // Space
                SearchByTitle(title);
            }
            else if (choice == "2")
            {
                Console.Write("Enter the author's name: ");
                string author = Console.ReadLine();
                Console.WriteLine(); // Space
                SearchByAuthor(author);
            }
            else if (choice == "3")
            {
                Console.Write("Enter the ISBN to search: ");
                string isbn = Console.ReadLine();
                Console.WriteLine(); // Space 
                SearchByISBN(isbn);
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                break;
            }
        } while (choice != "0");        
    }

    // Search by Title
    public void SearchByTitle(string title)
    {
        foundBooks.Clear(); // Clear previous search results

        foreach (var book in allBooks)
        {
            if (book.GetTitle().ToLower().Contains(title.ToLower()))
            {
                foundBooks.Add(book);
            }
        }
        DisplaySearchResults("Title", title);
    }

    // Search by Author
    public void SearchByAuthor(string author)
    {
        foundBooks.Clear(); // Clear previous search results

        foreach (var book in allBooks)
        {   
            if (book.GetAuthor().ToLower().Contains(author.ToLower()))
            {
                foundBooks.Add(book);
            }
        }
        DisplaySearchResults("Author", author);
    }

    // Search by ISBN
    public void SearchByISBN(string isbn)
    {
        foundBooks.Clear(); // Clear previous search results

        foreach (var book in allBooks)
        {
            if (book.GetISBN() == isbn)
            {
                foundBooks.Add(book);
            }
        }
        DisplaySearchResults("ISBN", isbn);
    }

    // Display search results
    private void DisplaySearchResults(string searchType, string searchResult)
    {
        if (foundBooks.Count == 0)
        {
            Console.WriteLine($"No books forund for {searchType}:  {searchResult}");
        }
        else 
        {
            Console.WriteLine($"Books found for {searchType}:  {searchResult}");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"- {book.GetTitle()} by {book.GetAuthor()} (ISBN: {book.GetISBN()})");
            }
        }
    }



}