using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperty
{
    public int speed { get; set; }
    public int durableCoefficient { get;set;}
    private List<Organ> organs = new List<Organ>();


    public Sprite sprite { get; set; }
    public Animation animation { get; set; }


    public UnitProperty clone()
    {
        return (UnitProperty)this.MemberwiseClone();
    }
}