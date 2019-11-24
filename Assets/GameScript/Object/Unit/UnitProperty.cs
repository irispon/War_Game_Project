using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperty
{
    public int speed { get; set; }
    private Race race;
    private DoubleKeyDictionary<Parts, string, Organ> organs;

    

    public Sprite sprite { get; set; }
    public Animation animation { get; set; }

    public UnitProperty(string raceUqName)
    {
        organs = new DoubleKeyDictionary<Parts, string, Organ>();
        setRace(raceUqName);
        setOrgan(race);
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

    private void setOrgan(Race race)
    {
        Organs organList = Organs.GetInstance();
        foreach (string organName in race.parts.Keys)
        {
            Organ organ = race.parts[organName];
            organs.Add(organ.part,organ.name,organ.Clone());

        }

        setOrganDurable();
    }

    private void setOrganDurable()
    {
        if (race.efficiency != 1.0f)
        {
            foreach (Organ organ in organs.Values)
            {

                organ.Durable = (int)(race.efficiency * organ.Durable);

            }
        }

    }



    public void TakeDamage(int damage)
    {
        Parts part = DictionaryAccessUtill.RandomKey(organs);
        TakeDamage(part, damage);

    }

    public void TakeHeal(int heal)
    {
        Parts part = DictionaryAccessUtill.RandomKey(organs);
        TakeHeal(part, heal);
    }

    public void TakeDamage(Parts part, int damage)
    {
        string randomkey = DictionaryAccessUtill.RandomKey(organs[part]);
        TakeDamage(part, randomkey, damage);
    }
    public void TakeHeal(Parts part, int heal)
    {
        string randomkey = DictionaryAccessUtill.RandomKey(organs[part]);
        TakeHeal(part, randomkey, heal);

    }
    public void TakeDamage(Parts part, string organ,int damage)
    {
        organs[part][organ].TkaeDamage(damage);
    }
    public void TakeHeal(Parts part, string organ, int heal)
    {
        organs[part][organ].TakeHeal(heal);

    }

    public UnitProperty clone()
    {
        return (UnitProperty)this.MemberwiseClone();
    }
}