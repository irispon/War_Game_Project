using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory:MonoBehaviour
{



    public static void Generate<T>() where T: Unit
    {

        GameObject gameObject = new GameObject();
        gameObject.AddComponent<T>();
        T t = gameObject.GetComponent<T>();
        t.Generate();
        Instantiate(gameObject);
        
        
    }

    

}
