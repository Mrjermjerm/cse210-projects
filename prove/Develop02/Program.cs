using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt prompt = new Prompt(); 
        // prompt.DisplayPrompt();

        // Entry entry = new Entry();
        // entry.DisplayEntry();

        Console.WriteLine($"Welcome to the Journal Program!");
        
        MainMenu mainMenu = new MainMenu();
        mainMenu.DisplayMain();

    }
}