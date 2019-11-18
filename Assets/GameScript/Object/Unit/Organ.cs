using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ
{

    /*상속... 아이템 오브젝트 등등 고려해봐야할 듯*/
    public string name { get; set; }
    public string uqName { get; set; }
    public int durable { get; set; }
    public int maxHp { get; set; }
    public int hp { get; set; }

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
