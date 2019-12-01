using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class WDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{
    public WDictionary():base()
     {
     }

    public WDictionary(IDictionary<TKey, TValue> dictionary):base(dictionary)
    {

    }
    public WDictionary(IEqualityComparer<TKey> comparer):base(comparer)
    {


    }
    public WDictionary(int capacity):base(capacity)
    {


    }
    public WDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer):base(dictionary,comparer)
    {


    }
    public WDictionary(int capacity, IEqualityComparer<TKey> comparer):base(capacity,comparer)
    {


    }
    protected WDictionary(SerializationInfo info, StreamingContext context):base(info,context)
    {
        

    }

    public WDictionary<TKey,TValue> Clone()
    {

        return new WDictionary<TKey, TValue>(this);
    }


}
