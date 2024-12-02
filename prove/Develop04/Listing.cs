


class Listing : Activities
{
    private List<string> _prompt = new List<string>();
    private Random random = new Random();

    public Listing():base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "")
    {
        _prompt.Add("Who are people that you appreciate?");
        _prompt.Add("What are personal strengths of yours?");
        _prompt.Add("Who are people that you have helped this week?");
        _prompt.Add("When have you felt the Holy Ghost this month?");
        _prompt.Add("Who are some of your personal heroes?");
    }

    public override void Action()
    {
        Console.Write($"\nList as many responses you can to the following prompt:\n--- {RandomPrompt()} ---\nYou may begin in: \n");
        BeginReflection();
        ReflectionQuestions();
    }

    public void ReflectionQuestions()
    {
        string time = Duration();
        
        if (int.TryParse(time, out int duration))
        {
            DateTime end = DateTime.Now.AddSeconds(duration);
            int inputCount = 0;

            while(DateTime.Now < end)
            {
                Console.Write($"> ");
                string userInput = Console.ReadLine();  

                if (!string.IsNullOrEmpty(userInput))
                {
                    inputCount++;
                }
                
            }
            Console.WriteLine($"You listed {inputCount} itmes!");
        }

        else
        {
            Console.WriteLine("Invalid duration input.");
        }
        
    }

    public string RandomPrompt()
    {
        return _prompt[random.Next(_prompt.Count)];
    } 

    public void BeginReflection() 
    {        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(4);
        
        while (DateTime.Now < futureTime)
        {
            Console.Write("4"); 

            Thread.Sleep(1000);

            Console.Write("\b \b"); 
            Console.Write("3"); 
            
            Thread.Sleep(1000); 
            Console.Write("\b \b"); 

            Console.Write("2"); 
            
            Thread.Sleep(1000); 
            Console.Write("\b \b"); 

            Console.Write("1");

            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}