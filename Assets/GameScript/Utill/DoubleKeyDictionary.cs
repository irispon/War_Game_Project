﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleKeyDictionary<K1,K2,Value>:Dictionary<K1,Dictionary<K2,Value>>
{

    public Value this[K1 key1,K2 key2]
    {
        get
        {
            if (!ContainsKey(key1) || !this[key1].ContainsKey(key2))
                throw new ArgumentOutOfRangeException();
            return base[key1][key2];
        }
        set
        {
            if (!ContainsKey(key1))
                this[key1] = new Dictionary<K2, Value>();
            this[key1][key2] = value;
        }

    }

    public void Add(K1 key1,K2 key2, Value value)
    {
        if (this[key1] == null)
        {
            this[key1] = new Dictionary<K2, Value>();

        }

            this[key1].Add(key2, value);

    }

    

    public new IEnumerable<Value> Values
    {
        get
        {
            return from baseDict in base.Values
                   from baseKey in baseDict.Keys
                   select baseDict[baseKey];
        }
    }


    public void Remove(K1 key1,K2 key2)
    {
        this[key1].Remove(key2);

    }

    public bool ContainsKey(K1 key1, K2 key2)
    {
        return base.ContainsKey(key1) && this[key1].ContainsKey(key2);
    }




}
