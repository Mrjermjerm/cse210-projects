

class Job
{
    private string _company;
    
    public string _jobTitle;

    public int _startYear;

    public int _endYear;

public Job(string _jobTitle, string _company, int _startYear, int _endYear)
{
    this._jobTitle = _jobTitle;
    this._company = _company;
    this._startYear = _startYear;
    this._endYear = _endYear;
}

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}