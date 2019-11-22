using System;

public class BoolParser 
{
    public static bool Parse(string text)
    {
        switch (text.ToLower())
        {
            case "true":
            case "t":
            case "1":
                return true;

            case "false":
            case "f":
            case "0":
                return false;

            default: throw new InvalidCastException("You can't cast that value to a bool!");
        }

    }

}
