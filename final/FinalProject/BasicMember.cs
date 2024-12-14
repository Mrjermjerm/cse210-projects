

class BasicMember : User
{

    public BasicMember(string userID, string name, string address,string membership) : base(userID, name, address, membership)
    {

    }

    public virtual int DaysToBorrow()
    {
        return 10;
    }

    


    
}