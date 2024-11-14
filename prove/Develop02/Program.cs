using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Welcome to the Journal Program!");
        
        MainMenu mainMenu = new MainMenu();
        mainMenu.DisplayMain();
    }
}