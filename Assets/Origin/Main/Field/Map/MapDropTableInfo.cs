using System.Collections.Generic;

public class MapDropTableInfo
{
   public string type;
   public List<string> uniqPool { private set; get; }
   public List<ItemInfo> uniqItem { private set; get; }

   public MapDropTableInfo()
    {

        uniqPool = new List<string>();
        uniqItem = new List<ItemInfo>();

    }




}