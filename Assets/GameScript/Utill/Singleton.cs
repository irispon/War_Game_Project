using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> where T :class,  new()
{
    private static Object lockObj= new Object();
    protected static T instance=null;



    public static T GetInstance()
    {
    
            if (instance == null)
          {  
            lock (lockObj)
            {
                if(instance == null)
                {
                    instance = new T();
                }
            }

        }

        
        return instance;
    }

}
