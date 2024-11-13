using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        // job1.DisplayJobDetails();

        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // job2.DisplayJobDetails();
        
        Resume myResume = new Resume();
        myResume._name = "Alison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayResume();

    }
}