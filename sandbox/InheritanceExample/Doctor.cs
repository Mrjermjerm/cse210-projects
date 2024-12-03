


class Doctor : Person
{
    private string _tools;
    public Doctor(string firstName, string lastName, int age, string tools) :base(firstName, lastName, age)
    {
        _tools = tools;
    }

    public string GetDoctorInformation()
    {
        return $"Tools: {_tools}, {GetPersonInfo()}";
    }
     
    public override string GetPersonInfo()
    {
        return $"Doctors are cooler than police, my tools: {_tools}, My info is: {base.GetPersonStats()}";
    }
}