using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race 
{
    public const string THINGDEF = "ThingDef";
    public const string DEFNAME = "defName";
    public const string EFFICIENCY = "efficiency";
    public const string PARTS = "parts";
    public const string CATAGORY = "Race";


    public WList<string> parts { get; set; } = null;
    public string uqName { get; set; }
    public string name { get; set; } = "default";
    public float efficiency { get; set; } = 1.0f;

    public Race Clone()
    {
        return (Race)this.MemberwiseClone();
    }
}
