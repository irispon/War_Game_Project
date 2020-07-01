using System;
using System.Collections.Generic;

public class MapMonsterInfo
{
    

    
    public int level { get; set; }
    public int minRange { get; set; }
    public int maxRange { get; set; }
    public List<Monster> UniqMonster { protected set; get; }
    protected List<Race> UniqMonsterPool {  set; get; }
  
    public MapMonsterInfo()
    {
        UniqMonster = new List<Monster>();
        UniqMonsterPool = new List<Race>();

    }




}



