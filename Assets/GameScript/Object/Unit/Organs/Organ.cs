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
    public int durable=0;

    public int hp { get; private set; } = 0;


    public float efficiency { get; set; } = 1.0f;
    public Parts part { get; set; }


    /// <summary>
    /// HP와 최대 HP(durable) 같이 초기화 시킬 때 사용
    /// </summary>
    public int Durable
    {
        get
        {
            return durable;
        }
        set
        {
            hp = value;
            durable = value;
        }

    }



    public void TkaeDamage(int damage)
    {
        int tmpHp = hp;
        tmpHp = hp-damage;
        if (tmpHp <= 0)
        {

            Debug.Log("파괴");
        }
        else
        {

            hp = tmpHp;
            Debug.Log("효율저하");
        }
    }

    public void TakeHeal(int heal)
    {
        int tmpHp = hp;
        tmpHp = hp + heal;
        if (tmpHp > durable)
        {
            hp = durable;
        }
        else
        {

            hp = tmpHp;
        }

    }

    public Organ Clone()
    {

        return (Organ)this.MemberwiseClone();
    }


}
