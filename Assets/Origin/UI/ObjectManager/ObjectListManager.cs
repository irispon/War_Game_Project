using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectListManager : SingletonObject<ObjectListManager>
{
    private List<GameObject> metaObjects;
    private Category state;
    [SerializeField]
    GameObject metaObject;

    protected override void Awake()
    {
        base.Awake();
        state = Category.None;
        metaObjects = new List<GameObject>();
    }
    public void Change(Category Mode)
    {

        switch (Mode)
        {
            case Category.Item:
                if (state != Category.Item)
                {
                    clear();
                    Debug.Log("아이템 목록");
                    state = Category.Item;
                    getItems(); 
                    
                }

                break;
            case Category.Tile:
                if (state != Category.Tile)
                {
                    clear();
                    state = Category.Tile;
                    Debug.Log("타일 목록");
                    getTiles();
                }

                break;
            default:
                break;
        }
    }

    private void getItems()
    {

        ItemDcitionary dictionary = ItemDcitionary.instance;
        foreach (ItemInfo info in dictionary.iteminfos.Values)
        {
            setMetaData(info);
        }
        
    }

    private void getTiles()
    {

        Dictionary<string,FieldProperty> dictionary = TileManager.instance.getDictionary();
        foreach (FieldProperty info in dictionary.Values)
        {
            setMetaData(info);
        }

    }

    private void setMetaData(IObjectInfo info)
    {

        // 크기 조정
        GameObject metaData = Instantiate(metaObject);
        metaData.transform.SetParent(transform);
        metaData.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = metaData.GetComponent<RectTransform>();
        rect.anchoredPosition3D = new Vector3(rect.anchoredPosition3D.x, rect.anchoredPosition3D.y, 0);
   
        //데이터 설정
        MetaData data = metaData.GetComponentInChildren<MetaData>();
        data.SetObjectInfo(info);
        metaObjects.Add(metaData);
       

    }

    private void clear()
    {
        foreach(GameObject gameObject in metaObjects){

            Destroy(gameObject);
        }
    }
}
