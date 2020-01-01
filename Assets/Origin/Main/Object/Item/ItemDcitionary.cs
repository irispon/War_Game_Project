using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDcitionary : SingletonObjectSlave<ItemDcitionary>
{
    public Dictionary<string, ItemInfo> iteminfos { get; private set; }

    protected override void Awake()
    {

        base.Awake();
        iteminfos = new Dictionary<string, ItemInfo>();
    }

    public void AddItem(ItemInfo info)
    {
        iteminfos.Add(info.getUqName(), info);
    }

    public ItemInfo GetItem(string itemUq)
    {

        if (iteminfos.ContainsKey(itemUq))
        {
            return iteminfos[itemUq].Copy();
        }
        else
        {

            throw new ArgumentNullException("해당 아이템이 존재하지 않습니다.");
        }
    
    }


    public GameObject Make(string itemUq)
    {
        ItemInfo iteminfo = GetItem(itemUq);
        switch (iteminfo.getItemType())
        {
            case ItemType.Apparel:
                break;
            case ItemType.Item:
               return Make<ItemObject>(iteminfo);
            case ItemType.Weapon:
                break;
            case ItemType.OtherThing:
                break;

            default:
                break;
        }
        throw new ArgumentException("해당되는 아이템이 없습니다.");
    }

    private GameObject Make<T>(ItemInfo iteminfo) where T : ItemObject
    {
        GameObject itemObject = new GameObject();
        itemObject.AddComponent<SpriteRenderer>();
        itemObject.AddComponent<T>();
        T t = itemObject.GetComponent<T>();
        t.Set(iteminfo);

        return itemObject;
        //Instantiate(itemObject);
    }


}
