using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitMaster : SingletonObject<UnitMaster>,IManager


/*필드에 올려진 객체들을 관리하는 역할을 하는 스크립트*/
{

    [SerializeField]
    GameObject format;

    private WDictionary<string, IWarGameUnit> units { get; set; }
    private int overlapKey=0;
    // Start is called before the first frame update

    void Start()
    {
        units = new WDictionary<string, IWarGameUnit>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void JoinUnit(WarGameUnitData uniqId, IWarGameUnit unit)
    {
       
        if (units.ContainsKey(uniqId.uniqName))
        {
            uniqId.uniqName = uniqId.uniqName + overlapKey++;
            unit.SetUnitData(uniqId);
        }
        
        units.Add(uniqId.uniqName, unit);
        Debug.Log("join성공" + uniqId.uniqName); 
    }
    public void JoinUnit(IWarGameUnit unit)
    {

        JoinUnit((WarGameUnitData)unit.GetData(),unit);
    }


    public void DetatchUnit(WarGameUnitData uniqId)
    {

        //실험 필요. 해당 uniqId로 삭제가 되는지
        units.Remove(uniqId.uniqName);


    }
    public void DetatchUnit(string uniqId)
    {

        //실험 필요. 해당 uniqId로 삭제가 되는지
        units.Remove(uniqId);


    }

    public GameObject MakeObject(Transform board, Vector3 positon, IObjectInfo info)
    {
        GameObject gameObject = MakeObject(info);
        Transform gameObjectTransform = gameObject.GetComponent<Transform>();
        gameObjectTransform.SetParent(board);
       // gameObjectTransform.position = Corrector.Correct(positon);
        gameObjectTransform.position = positon;
        return gameObject;
    }


    public GameObject MakeObject(GameObject board, Transform positon, IObjectInfo info)
    {
        return MakeObject(board.GetComponent<Transform>(), positon.position, info);
    }

    public GameObject MakeObject(GameObject board, Vector3 positon, IObjectInfo info)
    {
        return MakeObject(board.GetComponent<Transform>(), positon, info);
    }

    public GameObject MakeObject(Transform borad, Transform positon, IObjectInfo info)
    {
        return MakeObject(borad, positon.position, info);

    }

    public GameObject MakeObject(IObjectInfo info)
    {
        if (info.GetCategory() != Category.Unit)
        {
            throw new ArgumentException("해당 오브젝트는 유닛이 아닙니다. " + info.GetCategory().ToString());
        }
        GameObject gameObject;
        TileManager tileManager = TileManager.instance;
        gameObject = Instantiate(format);
        WarGameUnit warGameUnit = gameObject.GetComponent<WarGameUnit>();
        warGameUnit.Join(info);
        

        return gameObject;
    }

    public List<IObjectInfo> GetDatas()
    {
        List<IObjectInfo> objectInfos = new List<IObjectInfo>();
        foreach (IWarGameUnit info in units.Values)
        {
            objectInfos.Add(info.GetData());

        }
 

        return objectInfos;
    }


    public GameObject GetFormat()
    {

        return format;
    }

    /*
    public void Interact(IWarGameObject fromUnit, IWarGameObject toUnit, WarGameAbility ability )
    {


    }
        
    */


}
