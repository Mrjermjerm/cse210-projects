

class BasicMember : User
{

    public BasicMember(string userID, string name, string address,string membership) : base(userID, name, address, membership)
    {

    }

    public override int DaysToBorrow()  
    {
        return 10;
    }

    
}