


using System.Runtime.InteropServices;

class Reflection : Activities
{

    private List<string> _prompt = new List<string>();
    private List<string> _reflectionQuestions = new List<string>();
    private Random random = new Random();

    public Reflection():base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.","") 
    {   
        _prompt.Add("Think of a time when you stood up for someone else.");
        _prompt.Add("Think of a time when you did something really difficult.");
        _prompt.Add("Think of a time when you helped someone in need.");
        _prompt.Add("Think of a time when you did something truly selfless.");

        _reflectionQuestions.Add("Why was this experience meaningful to you?");
        _reflectionQuestions.Add("Have you ever done anything like this before?");
        _reflectionQuestions.Add("How did you get started?");
        _reflectionQuestions.Add("How did you feel when it was complete?");
        _reflectionQuestions.Add("What made this time different than other times when you were not as successful?");
        _reflectionQuestions.Add("What is your favorite thing about this experience?");
        _reflectionQuestions.Add("What could you learn from this experience that applies to other situations?");
        _reflectionQuestions.Add("What did you learn about yourself through this experience?");
        _reflectionQuestions.Add("How can you keep this experience in mind in the future?");
    }

    public string RandomPrompt()
    {
        return _prompt[random.Next(_prompt.Count)];
    } 

    public string RandomReflectionQuestion()
    {
        return _reflectionQuestions[random.Next(_reflectionQuestions.Count)];
    } 

    public override void Action()
    {
        Console.Write($"\nConsider the following prompt:\n\n--- {RandomPrompt()} ---\n\nWhen you have something in mind, press enter to contiue.");
        string contiue = Console.ReadLine();

        if (contiue == "")
        {
            Console.WriteLine(""); // Space
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write($"You may begin in: ");

            BeginReflection();
            Console.Clear(); 

            ReflectionQuestions();
        }
        else 
        {
            Console.WriteLine("Invalid option.");
        }
    }

    public void ReflectionQuestions()
    {
        string time = Duration();

        if (int.TryParse(time, out int duration))
        {
            DateTime end = DateTime.Now.AddSeconds(duration);

            while(DateTime.Now < end)
            {
                Console.Write($"> {RandomReflectionQuestion()} ");
                Spinner(); 
                Console.WriteLine();
            }
        }
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

    public void Spinner() 
    {        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(5);
        
        while (DateTime.Now < futureTime)
        {
            Console.Write("\\"); 

            Thread.Sleep(500);  

            Console.Write("\b \b"); 
            Console.Write("/"); 
            
            Thread.Sleep(500);
            Console.Write("\b \b"); 
        }
    }
}