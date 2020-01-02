using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager :SingletonObjectSlave<TileManager>,IManager
{
    public GameObject tile;
    private Category category;
    private Dictionary<string,FieldProperty> floorProperties;
    //private Dictionary<string, FieldProperty> WallProperties;
   

    protected override void Awake()
    {
      
        base.Awake();
        floorProperties = new Dictionary<string, FieldProperty>();
        category = Category.Tile;
            //WallProperties = new Dictionary<string, FieldProperty>();  


    }


    public void addProperty(FieldProperty fieldProperty)
    {
        Debug.Log("바닥 추가"+ fieldProperty.uqName);
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

    public GameObject MakeFloor(string uqName)
    {

        GameObject floorObj = Instantiate(this.tile);
        Tile tile = floorObj.GetComponent<Tile>();
        FieldProperty fieldProperty;

        try
        {

            fieldProperty = floorProperties[uqName];

        }
        catch (Exception ex)
        {

       
            throw new ArgumentException("바닥 생성 오류! "+ex);
      
        }

        tile.setProperty(fieldProperty);
        return floorObj;
    }

    public Dictionary<string,FieldProperty> getDictionary()
    {

        return floorProperties;
    }

    public void MakeObject()
    {
       
    }

    public GameObject MakeObject(IObjectInfo info)
    {
        if (info.GetCategory() != Category.Tile)
        {
            throw new ArgumentException("해당 오브젝트는 타일이 아닙니다. "+ info.GetCategory().ToString());
        }
        GameObject gameObject;
        TileManager tileManager = TileManager.instance;
        gameObject = tileManager.MakeFloor(info.GetUqName());

        return gameObject;
    }
}
