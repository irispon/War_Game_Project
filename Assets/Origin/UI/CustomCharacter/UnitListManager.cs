using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitListManager : SingletonObject<UnitListManager>
{
    [SerializeField]
    GameObject charData;

    UnitList list;


    protected override void Awake()
    {
        base.Awake();
        CustomUnitManager.instance.Join(this);
        list = UnitList.instance;
    }

    public void Make(string raceUqName)
    {
        Make(Races.GetInstance().getRace(raceUqName));

    }
    public void Make()
    {

        Races races = Races.GetInstance();

        Make(races.getRace());
   

    }
    private void Make(Race race)
    {
        UnitProperty unit = new UnitProperty(race);
        GameObject charData = Instantiate(this.charData);
        charData.GetComponent<CharData>().SetUnitproperty(unit);
        list.Add(charData);
    }



    public void Another()
    {

    }
}
