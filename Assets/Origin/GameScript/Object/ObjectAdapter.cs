using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*사멸 코드*/
public class ObjectAdapter
{
    private IObjectInfo info;

    public ObjectAdapter(IObjectInfo info)
    {
        SetObject(info);
    }

    public ObjectAdapter()
    {
    }

    public void SetObject(IObjectInfo info)
    {
        this.info = info;

    }

    public GameObject Creat()
    {
        GameObject gameObject=null;

        if (info.GetCategory() == Category.Item)
        {
            ItemDcitionary itemDcitionary = ItemDcitionary.instance;
            gameObject= itemDcitionary.Make(info.GetUqName());

        }else if (info.GetCategory() == Category.Tile)
        {
            TileManager tileManager = TileManager.instance;
            gameObject= tileManager.MakeFloor(info.GetUqName());
        }

        FieldManager fieldManager = FieldManager.GetFieldManager();

        gameObject.transform.SetParent(fieldManager.GetBoard());
      

        return gameObject;
    }
}
