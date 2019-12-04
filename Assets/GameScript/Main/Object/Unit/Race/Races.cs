using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Races:Singleton<Races>
{

    private Dictionary<string, Race> races;

    /// <summary>
    /// GetInstance()를 이용하여 생성하세요
    /// </summary>
    public Races()
    {
        races = new Dictionary<string, Race>();

    }

    public void addRace(Race race)
    {
        races.Add(race.uqName, race);

    }
    public Race getRace()
    {
        return getRace(DictionaryAccessUtill.RandomKey(races));
    }

    public Race getRace(string uqName)
    {
        Race race = races[uqName].Clone();
    

        return race;
    }

   

}
