using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperty:IObjectInfo
{
    public string unitName="NoName";
    public string midleName = "NoName";
    public string unitUqName= "NoName";
    public int speed { get; set; }
    private Race race;

    

    public Sprite sprite { get; set; }
    public Animation animation { get; set; }

    public UnitProperty():this(Races.GetInstance().getRace())
    {

    }

    public UnitProperty(string raceUqName): this(Races.GetInstance().getRace(raceUqName))
    {
     

    }

    public UnitProperty(Race race)
    {

        setRace(race);
    }

    public void setRace(string uqName)
    {

     
        try
        {
            race = Races.GetInstance().getRace(uqName);


        }
        catch (Exception e)
        {

            throw new System.ArgumentException("Race 로딩 오류"+e);

        }
    


    }
    public void setRace(Race race)
    {


        this.race = race.Clone();

    }


    private void setOrganDurable()
    {


    }

    public UnitProperty clone()
    {
        return (UnitProperty)this.MemberwiseClone();
    }


    public string GetName()
    {
        return unitName +" "+midleName;
    }

    public string GetUqName()
    {
        return unitUqName;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Category GetCategory()
    {
        return Category.Unit;
    }

    public IManager GetParent()
    {
        throw new NotImplementedException();
    }

    public DoubleKeyDictionary<Parts, string, Organ> GetOrgans()
    {

        return race.parts;
    }


    /*
        public void TakeDamage(int damage)
        {
            Parts part = DictionaryAccessUtill.RandomKey(race.parts);
            TakeDamage(part, damage);

        }

        public void TakeHeal(int heal)
        {
            Parts part = DictionaryAccessUtill.RandomKey(race.parts);
            TakeHeal(part, heal);
        }

        public void TakeDamage(Parts part, int damage)
        {
            string randomkey = DictionaryAccessUtill.RandomKey(race.parts[part]);
            TakeDamage(part, randomkey, damage);
        }
        public void TakeHeal(Parts part, int heal)
        {
            string randomkey = DictionaryAccessUtill.RandomKey(race.parts[part]);
            TakeHeal(part, randomkey, heal);

        }
        public void TakeDamage(Parts part, string organ,int damage)
        {
            race.parts[part][organ].TkaeDamage(damage);
        }
        public void TakeHeal(Parts part, string organ, int heal)
        {
            race.parts[part][organ].TakeHeal(heal);

        }
        */


}