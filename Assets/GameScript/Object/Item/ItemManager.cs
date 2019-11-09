using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour /*베이스 아이템 오브젝트. 기본적인 속성 정의 후 진로가 나뉘어짐 ex) 무기, 장비, 기본 오브젝트 등등 커피에 크림타는 패턴을 뭐라하더라 그거 같은거(데코레이트 패턴) */
{
    private Dictionary<string, ItemObject> items;
    public GameObject weapon;
    public GameObject wear;
    public GameObject sceneryObj;
    public GameObject item;
    private static ItemManager instance;

    /*새로운 아이템 변수...? 프리펩 만들어두기...*/


     void Awake()
    {
        if(instance == null)
        {

            instance = this;
        }else if(instance != this)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        items = new Dictionary<string, ItemObject>();

    }


    public static ItemManager GetInstatnce()
    {
        return instance;
    }


    public void Make()
    {

        /*게임 오브젝트 component 추가 기본 deafault 설정 필요할 듯.  */
        
    }

    public void Join(string def,ItemObject item)
    {

        items.Add(def,item);

    }

    public ItemObject get(string def)
    {

        return items[def].Clon();
    }
 
    public void delete(string def)
    {
        items.Remove(def);

    }

    public ItemManager DecoWeapon()
    {

        return this;
    }

    public ItemManager DecoWear()
    {

        return this;
    }

    public ItemManager DecoFuniture()
    {

        return this;
    }

    public void Add(ItemInfo iteminfo)
    {
        GameObject item = Instantiate(this.item);
        item.GetComponent<ItemObject>().Make(iteminfo);
        
    }
}
