using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race
{
    public const string THINGDEF = "ThingDef";
    public const string DEFNAME = "defName";
    public const string EFFICIENCY = "efficiency";
    public const string PART = "part";
    public const string CATAGORY = "Race";
    public const string ORGANDEF = "organDef";
    public const string ORGANNAME = "name";

    // public WList<string> parts { get; set; } = null;
    public DoubleKeyDictionary<Parts, string, Organ> parts { get; set; } = null;
    public string uqName { get; set; }
    public string name { get; set; } = "default";
    public float efficiency { get; set; } = 1.0f;

    public Race()
    {
        parts = new DoubleKeyDictionary<Parts, string, Organ>();

    }
    public void setDurable(float coefficient)
    {


    }

    public Race Clone()
    {
        parts = parts.Clone();
        return (Race)this.MemberwiseClone();
    }


}
