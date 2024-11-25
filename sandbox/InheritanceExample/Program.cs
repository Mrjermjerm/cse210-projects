


using System.Buffers.Binary;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hey Bob");

        Console.WriteLine("\n"); // Space

        Person bob = new Person("Bob", "Billy", 37);
        Console.WriteLine(bob.GetPersonInfo());

        Doctor doctorBob = new Doctor("Bob", "Budge", 65, "Hack Saw");
        Console.WriteLine(doctorBob.GetDoctorInformation());
        Console.WriteLine(doctorBob.GetPersonInfo());

        Console.WriteLine("\n"); // Space

        Police policeDoug = new Police("Doug", "Denver", 40, "Taser");
        Console.WriteLine(policeDoug.GetPoliceInformation());
        Console.WriteLine(policeDoug.GetPersonInfo());
    }
}