using System;
using UnityEngine;

public  class WarGameAbility:IAbility, ICloneable
{

    public string uniqId="defalut";
    public string name="noName";

    public int coolTime;
    public float power;
    //Target target;
    public Attack attack;
    public Buff buff;
    public DeBuff deBuff;

    public WarGameAbility chainAbility;

    public WarGameAbility()
    {
     
  
        attack.activate = false;
        buff.activate = false;
        deBuff.activate = false;


    }
    public void setData(Attack attack,Buff buff,DeBuff deBuff)
    {
        if (attack.activate == true)
        {
            this.attack = attack;

        }
        if (buff.activate == true)
        {
            this.buff = buff;
        }
        if (deBuff.activate == true)
        {

            this.deBuff = deBuff;
        }

    }


    public void Effect()
    {
        if (attack.activate == true) {

        }

        if (buff.activate == true)
        {

        }

        if(deBuff.activate == true)
        {


        }
    }



    public void CoolTime(float time)
    {

    }

    public void Activate(WarGameUnit activator ,WarGameUnit target)
    {
       

    }


    public void Attack(WarGameUnit target)
    {
        Debug.Log("공격");
    }

    public void Buff(WarGameUnit activator, WarGameUnit target)
    {

        if (buff.activate == true)
        {
            if (buff.selfApply == true)
            {
                Debug.Log("버프 적용"+activator.name);

            }
            else
            {


            }
        }
        else
        {


        }

    }

    public void Debuff(WarGameUnit activator, WarGameUnit target)
    {
 

        if (deBuff.activate == true)
        {
            if (deBuff.selfApply == true)
            {
                Debug.Log("디버프 적용" + activator.name);

            }
            else
            {


            }
        }
        else
        {


        }


    }
    public object Clone()
    {
        WarGameAbility warGameAbility = new WarGameAbility();
        warGameAbility.setData(attack,buff,deBuff);

        return warGameAbility;
    }
}

