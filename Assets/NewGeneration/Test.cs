using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterLoadManager loadManager = new CharacterLoadManager();
        WeaponDataManager weaponDataManager = new WeaponDataManager();
        test1();
        DataManager.GetInstance().Find<WarGameUnitData>("Sera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test1()
    {
        DataManager dataManager = DataManager.GetInstance();
      WeaponData data1=  dataManager.Find<WeaponData>("강한무기");
      WeaponData data2 = dataManager.Find<WeaponData>("좀강한무기");
      WeaponData data3 = dataManager.Find<WeaponData>("강한무기");
      WeaponData data4 = dataManager.Find<WeaponData>("없는 이름");

        data1.name = "새롭게 바뀐 이름";

        Debug.Log("data1" + data1.name);
        Debug.Log("data2" + data2.name);
        Debug.Log("data3" + data3.name);
        Debug.Log("data4" + data4.name);
    }
}
