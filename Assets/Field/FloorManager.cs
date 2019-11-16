using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager :MonoBehaviour
{
    public GameObject floor;
    public Dictionary<string,FieldProperty> fieldProperties;
    private static FloorManager Instance;

    private void Awake()
    {
        if (Instance ==null)
        {
            Instance = this;
            fieldProperties = new Dictionary<string, FieldProperty>();
        }
        else
        {
            Destroy(gameObject);
          

        }

        DontDestroyOnLoad(gameObject);
     

    }

    public static FloorManager getInstance()
    {

        return Instance;
    }


    public void addProperty(FieldProperty fieldProperty)
    {
        fieldProperties.Add(fieldProperty.uqName,fieldProperty);

    }
  
    public GameObject MakeFloor(Vector3 vector)
    {
        string randomName = (string)DictionaryAccessUtill.RandomKey(fieldProperties);

        Debug.Log(randomName);
        return MakeFloor(randomName, vector);

    }
    public GameObject MakeFloor(string name, Vector3 vector)
    {
        GameObject floorObj = Instantiate(this.floor);
        Floor floor = floorObj.GetComponent<Floor>();
        FieldProperty fieldProperty;

        try
        {
            fieldProperty = fieldProperties[name];

        }
        catch (Exception ex)
        {

            Debug.Log("바닥 이름을 잘못 설정했습니다.");
            return null;
        }

        floor.setProperty(fieldProperty);
        floor.setTransform(vector);
        return floorObj;
    }



}
