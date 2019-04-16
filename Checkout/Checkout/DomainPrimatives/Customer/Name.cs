using System;
using System.Text.RegularExpressions;

public class Name
{ 
	public Name(string name)
	{
        //Validation
        //Origin???

        //Length
        if (name != null && name.Length() <= 20)
        {
            //Lexical
            Regex lexicalRegex = new Regex(@"[A-Za-z]\s+*", RegexOptions.Compiled|RegexOptions.IgnoreCase);
            MatchCollection match = lexicalRegex.Matches(name);
            if(match.Count != 0)
            {
                //Syntax
                Regex syntaxRegex = new Regex(@"[A-Z][a-z]\s+*", RegexOptions.Compiled);
                match = syntaxRegex.Matches(name);
                if (match.Count != 0)
                {
                    //Semantics???

                    name = Name;
                }
            }
        }
	}

    private Name name;
    public Name Name
    {
        get { return name; }
        set { SetField(ref name, value); }
    }

}
