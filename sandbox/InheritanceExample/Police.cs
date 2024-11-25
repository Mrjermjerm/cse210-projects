



class Police : Person
{
    private string _weapons;
    public Police(string firstName, string lastName, int age, string weapons) :base(firstName, lastName, age)
    {
        _weapons = weapons;
    }

    public string GetPoliceInformation()
    {
        return $"Weapons: {_weapons}, {base.GetPersonInfo()}";
    }
}