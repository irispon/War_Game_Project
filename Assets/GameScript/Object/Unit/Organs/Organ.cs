using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ
{
    /*XMLTAGS*/
    public const string THINGDEF = "ThingDef";
    public const string DEFNAME = "defName";
    public const string PART = "part";
    public const string DURABLE = "durable";
    public const string NECESSARY = "necessary";
    public const string EFFICIENCY = "efficiency";
    public const string CATAGORY= "Organ";
    /*XMLTAGS*/


    /*상속... 아이템 오브젝트 등등 고려해봐야할 듯*/
    public string name { get; set; } = "이름 없음";
    public string uqName { get; set; } = "missing";
    public bool necessary { get; set; } = false;
    public int durable { get; set; } = 0;
    public int maxHp { get; set; } = 0;
    public int hp { get; set; } = 0;


    public float efficiency { get; set; } = 1.0f;

    public Parts parts { get; set; }


    public void GetDamage(int damage)
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
