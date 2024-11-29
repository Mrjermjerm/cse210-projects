


using System.Diagnostics;
using System.Globalization;

class Breathing : Activities
{
    private string _titleName;

    public Breathing()
    {
        _titleName = "Breathing Activity";
    }

    public string WelcomeBreathingActivity()
    {
        return $"{base.WelcomeMessage()}{_titleName}";
    }
}