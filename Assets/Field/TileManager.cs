using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager :MonoBehaviour
{
    public GameObject tile;
    private Dictionary<string,FieldProperty> floorProperties;
    private Dictionary<string, FieldProperty> WallProperties;
    private static TileManager Instance;

    private void Awake()
    {
        if (Instance ==null)
        {
            Instance = this;
            floorProperties = new Dictionary<string, FieldProperty>();
            //WallProperties = new Dictionary<string, FieldProperty>();  
        }
        else
        {
            Destroy(gameObject);
          

        }

        DontDestroyOnLoad(gameObject);
     

    }

    public static TileManager getInstance()
    {

        return Instance;
    }


    public void addProperty(FieldProperty fieldProperty)
    {
        floorProperties.Add(fieldProperty.uqName,fieldProperty);

    }
  
    //public GameObject MakeFloor(Vector3 vector, Layer type)
    //{
    //    string randomKey = (string)DictionaryAccessUtill.RandomKey(floorProperties);


    //    return MakeFloor(randomKey, vector, type);

    //}
    public GameObject MakeFloor(string name, Vector3 vector)
    {
        
        GameObject floorObj = Instantiate(this.tile);
        Tile tile = floorObj.GetComponent<Tile>();
        FieldProperty fieldProperty;

        try
        {
            
            fieldProperty = floorProperties[name];

        }
        catch (Exception ex)
        {

            Debug.Log("바닥 이름을 잘못 설정했습니다.");
            return null;
        }

        tile.setProperty(fieldProperty);
        tile.setTransform(vector);
        return floorObj;
    }



}
