

using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Serialization;

class Activities
{

    private string _title;
    private string _description;
    private string _timeToWork;
    private string _duration;

    public Activities(string title, string description, string duration)
    {
        _title = title;
        _description = description;
        _timeToWork = "How long, in seconds, would you like for your session to be? ";
        _duration = duration;
    }
    
    public string WelcomeMessage()
    {
        Console.Clear();
        return $"Welcome to the {_title}";
    }

    public string DescriptionMessage()
    {
        return $"{_description}";
    }

    public string PromptForTimeToWork()
    {
        return $"{_timeToWork}";
    }

    public void Time() // Duration for activity
    {
        _duration = Console.ReadLine();
        
        if (int.TryParse(_duration, out int delay))
        {
            DateTime currentTime = DateTime.Now;            
            DateTime targetTime = currentTime.AddSeconds(delay);
            DateTime timeOfActivityAfterAnimation = targetTime.AddSeconds(3); // Same Time as Animation

            Console.Clear();
            Console.WriteLine("Get ready...");

            Animation();

            while (DateTime.Now < timeOfActivityAfterAnimation)
            {
               Action();
            }

        Console.WriteLine("\n"); // Space
        Console.WriteLine($"Well done!!");
        Animation();

        Console.WriteLine(); // Space

        Console.WriteLine($"You have completed another {_duration} seconds of the {_title}");
        Animation();

        Menu menu = new Menu();
        menu.GetPrompt();
        }
        else
        {
            Console.WriteLine($"Invalid input. Please input a number");
        }
    }

    public void Animation() // Animation spinner
    {        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(3);
        
        while (DateTime.Now < futureTime)
        {
            Console.Write("\\"); // Display the / character

            Thread.Sleep(500); // Sleep 

            Console.Write("\b \b"); // Erase the \ character
            Console.Write("/"); // Replace it with the / character
            
            Thread.Sleep(500); // Sleep 
            Console.Write("\b \b"); // Erase the / character
        }
    }

    public virtual void Action()
    {
       
    }

    public string Duration()
    {
        return _duration;
    }
}