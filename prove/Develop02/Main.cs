


class MainMenu
{

    public void DisplayMain()
    {
        Console.WriteLine($"Please Select one of the following choices: ");
        
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}