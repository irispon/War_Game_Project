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

    private void getItems()
    {

        ItemDcitionary dictionary = ItemDcitionary.instance;
        foreach (ItemInfo info in dictionary.iteminfos.Values)
        {
            AddMetaData(info);
        }

    }

    public void setMetaDatas(List<IObjectInfo> infos)
    {

        if(state!= infos[0].GetCategory())
        {
           
            clear();
            state = infos[0].GetCategory();
     
   
        foreach (IObjectInfo info in infos)
        {
            AddMetaData(info);
        }
        }
    }

    private void AddMetaData(IObjectInfo info)
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
        foreach (GameObject gameObject in metaObjects)
        {

            Destroy(gameObject);
        }
    }
}

