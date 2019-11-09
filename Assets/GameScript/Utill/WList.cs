using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WList<T> : List<T>
{

   public WList<T> clone()
    {
        WList<T> clone = new WList<T>();
        clone.AddRange(this);
             
        return clone;
    }
}
