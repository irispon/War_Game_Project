using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race 
{
    List<string> organs;
    public string uqName { get; set; }
    public string name { get; set; }
    public float efficiency { get; set; }

    public Race Clone()
    {
        return (Race)this.MemberwiseClone();
    }
}
