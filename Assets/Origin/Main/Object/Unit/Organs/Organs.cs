using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organs:SingletonSlave<Organs>
{


    private Dictionary<string, Organ> organs;

    /// <summary>
    /// getInstance()를 이용하여 생성하세요
    /// </summary>
    /// 
    
   public Organs()
    {

            organs = new Dictionary<string, Organ>();

    }

    
    public void addOrgan(Organ organ)
    {
        organs.Add(organ.uqName, organ);

    }
    public Organ getOrgan()
    {
        return getOrgan(DictionaryAccessUtill.RandomKey(organs));

       
    }
    public List<IListObjectInfo> GetOrgans()
    {
        
        return new List<IListObjectInfo>(organs.Values);
    }

    public Organ getOrgan(string uqName)
    {


        return organs[uqName].Clone();
    }
    
}
