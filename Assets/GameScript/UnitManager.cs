using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager 
{

    private static UnitManager unitManager=null;
    private bool select=false;
    private static WList<Unit> units;

    private UnitManager()
    {
        units = new WList<Unit>();
    }

    public static UnitManager getInstance()
    {
        if (unitManager == null)
        {
            unitManager = new UnitManager();
            
            
        }

        return unitManager;
    }


    public void Join(Unit unit)//유닛 다중 선택(Unit 개체가 호출)
    {
        units.Add(unit);
       
    }

    public void Detach(Unit unit)//유닛 해제(Unit 개체가 호출)
    {

       bool remove= units.Remove(unit);
       System.Diagnostics.Debug.WriteLine("유닛 해제 결과 "+remove);
      

    }


    public void Move(Vector3 position)//매니저가 Unit을 호출
    {

        object Lock = new object();

        lock (Lock)
        {
            WList<Unit> clon_units = units.Clone();

            foreach (Unit unit in clon_units)
            {

                unit.Move(position);
                unit.Deselect();
            }

            clon_units.Clear();
            // do stuff
        }



    }

    
}
