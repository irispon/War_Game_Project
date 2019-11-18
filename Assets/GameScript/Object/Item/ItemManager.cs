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


    public void Join(string def,ItemObject item)
    {

        items.Add(def,item);

    }

    public void Get(string def)
    {

       
        GameObject item = Instantiate(this.item);
        try
        {
            Debug.Log("확인"+ items[def].itemInfo.getDecription() + def);
            item.GetComponent<ItemObject>().Copy(items[def].Clon());
            item.name = "copy"+ items[def].itemInfo.getDefName();
        }
        catch (Exception e)
        {

            Debug.Log("아이템 불러오기 실패!!"+e);
        }

    }
 
    public void Delete(string def)
    {
        items.Remove(def);

    }


    public void Make(ItemInfo iteminfo)
    {
        GameObject item = Instantiate(this.item);
        System.Random random = new System.Random();
        Vector3 vec = new Vector3(random.Next(0, 10),  random.Next(0, 10), 0);
        item.GetComponent<Transform>().position = vec;
        item.GetComponent<ItemObject>().Make(iteminfo);
        Get(iteminfo.getUqName());


    }
}
