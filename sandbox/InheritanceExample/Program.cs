


using System.Buffers.Binary;

class Program
{

    public static void SetPersonFirstName(Person person, string firstName)
    {
        person.SetFirstName(firstName);
    }


    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hey Bob");

        Console.WriteLine("\n"); // Space

        Person bob = new Person("Bob", "Billy", 37);
        Console.WriteLine(bob.GetPersonInfo());

        Person betty = new Person("Betty", "Shell", 20);
        Console.WriteLine(betty.GetPersonInfo());

        Doctor doctorBob = new Doctor("Bob", "Budge", 65, "Hack Saw");
        Console.WriteLine(doctorBob.GetDoctorInformation());
        Console.WriteLine(doctorBob.GetPersonInfo());

        Console.WriteLine("\n"); // Space

        Police policeDoug = new Police("Doug", "Denver", 40, "Taser");
        Console.WriteLine(policeDoug.GetPoliceInformation());
        Console.WriteLine(policeDoug.GetPersonInfo());

        SetPersonFirstName(policeDoug, "Doug the second");
        Console.WriteLine(policeDoug.GetPoliceInformation());
        Console.WriteLine(policeDoug.GetPersonInfo());

        SetPersonFirstName(bob, "Bobby");
        Console.WriteLine(bob.GetPersonInfo());
        Console.WriteLine();


        List<Person> people = new List<Person>();
        people.Add(bob);
        people.Add(betty);
        people.Add(doctorBob);
        people.Add(policeDoug);

        foreach(Person person in people)
        {
            Console.WriteLine(person.GetPersonInfo());
        }
    }
}