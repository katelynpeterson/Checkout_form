using System;

public class Name
{ 
	public Name(string name)
	{
        name =  Name ?? null;

	}

    private Name name;
    public Name Name
    {
        get { return name; }
        set { SetField(ref name, value); }
    }

}
