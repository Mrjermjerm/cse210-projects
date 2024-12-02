


using System.Diagnostics;
using System.Globalization;

class Breathing : Activities
{


    public Breathing():base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.","") 
    {
        
    }

    public override void Action()   
    {
        Console.Write("\nBreath in...");
        BreathIn();

        Console.Write("\nNow breath out...");
        BreathOut();
    }

    public void BreathIn() 
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

    public void BreathOut() 
    {        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(6);
        
        while (DateTime.Now < futureTime)
        {
            Console.Write("6");

            Thread.Sleep(1000);
            Console.Write("\b \b"); 

            Console.Write("5");

            Thread.Sleep(1000);
            Console.Write("\b \b"); 
            
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