

using System.Security.Cryptography;
using System.Security.Principal;

class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;

    public Person(string firstName, string lastName, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
    }

    public virtual string GetPersonInfo()
    {
        return $"{_firstName}, {_lastName}, {_age}";
    }

    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
    }
}