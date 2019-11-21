using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ
{
    /*XMLTAGS*/
    public static readonly string THINGDEF = "ThingDef";
    public static readonly string DEFNAME = "defName";
    public static readonly string PART = "part";
    public static readonly string DURABLE = "durable";
    public static readonly string NECESSARY = "necessary";
    public static readonly string EFFICIENCY = "efficiency";
    /*XMLTAGS*/


    /*상속... 아이템 오브젝트 등등 고려해봐야할 듯*/
    public string name { get; set; } = "이름 없음";
    public string uqName { get; set; } = "missing";
    public bool necessary { get; set; } = false;
    public int durable { get; set; } = 0;
    public int maxHp { get; set; } = 0;
    public int hp { get; set; } = 0;


    public float efficiency { get; set; }

    public Parts parts { get; set; }


    public void GetDamage(int damager)
    {


    }

    public void CureDamage(int cure)
    {


    }

    public Organ Clone()
    {

        return (Organ)this.MemberwiseClone();
    }

   

}
