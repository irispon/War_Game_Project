using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organs 
{

    public static Organs instance=null;
    private Dictionary<string, Organ> organs;

   private Organs()
    {

            organs = new Dictionary<string, Organ>();

    }

    public static Organs getOrgans()
    {

        if(instance == null)
        {
            instance = new Organs();
        }

        return instance;
    }

    public void addOrgan(Organ organ)
    {
        organs.Add(organ.uqName, organ);

    }

    public Organ getOrgan(string uqName)
    {


        return organs[uqName].Clone();
    }
    
}
