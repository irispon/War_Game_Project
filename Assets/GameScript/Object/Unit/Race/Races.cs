using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Races:Singleton<Races>
{

    private Dictionary<string, Race> races;

    /// <summary>
    /// GetInstance()를 이용하세요
    /// </summary>
    public Races()
    {
        races = new Dictionary<string, Race>();

    }

    public void addRace(Race race)
    {
        races.Add(race.uqName, race);

    }

    public Race getOrgan(string uqName)
    {


        return races[uqName].Clone();
    }

   

}
