using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUnitManager : SingletonObject<CustomUnitManager>
{
    private UnitListManager listManager { get; set; } = null;
    private UnitCreatManager unitCreatManager { get; set; } = null;






    /// <summary>
    /// 다른 관리자들 등록
    /// </summary>
    /// <param name="listManager"></param>
    /// 


    public void MakeCharacter()
    {
        if(unitCreatManager != null)
        {
            Debug.Log("생성");
            listManager.Make();

        }
    }

    public void Join(UnitListManager listManager)
    {
 
            Debug.Log("초기화");
            this.listManager = listManager;

    }

    public void Join(UnitCreatManager unitCreatManager)
    {

            Debug.Log("초기화");
            this.unitCreatManager = unitCreatManager;
       


    }

}
