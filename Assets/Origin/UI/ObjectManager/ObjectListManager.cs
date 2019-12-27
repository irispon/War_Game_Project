using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectListManager : SingletonObject<ObjectListManager>
{
    private List<GameObject> metaObjects;
    [SerializeField]
    GameObject metaObject;

    protected override void Awake()
    {
        base.Awake();
        metaObjects = new List<GameObject>();
    }
    public void Change(Manager Mode)
    {
        clear();

        switch (Mode)
        {
            case Manager.ItemManager:
                Debug.Log("아이템 목록");
                getItems();
                break;
            case Manager.TileManager:
                Debug.Log("타일 목록");
                getTiles();
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


            GameObject metaData = Instantiate(metaObject);
            Image image = metaData.GetComponentInChildren<Image>();
        TextMeshProUGUI textMesh = metaData.GetComponentInChildren<TextMeshProUGUI>();
            image.sprite = info.GetSprite();
             metaData.transform.SetParent(transform);
        metaData.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = metaData.GetComponent<RectTransform>();
        rect.anchoredPosition3D = new Vector3(rect.anchoredPosition3D.x, rect.anchoredPosition3D.y, 0);
         textMesh.text = info.GetName();
            metaObjects.Add(metaData);
       

    }

    private void clear()
    {
        foreach(GameObject gameObject in metaObjects){

            Destroy(gameObject);
        }
    }
}
