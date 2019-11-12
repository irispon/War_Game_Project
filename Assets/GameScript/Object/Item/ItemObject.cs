using System;
using UnityEngine;

public class ItemObject: MonoBehaviour
{
    public ItemInfo itemInfo;
    private SpriteRenderer graphic;

    public void Make(ItemInfo itemInfo)
    {
        
        Set(itemInfo);
        this.Join();

    }

    private void Awake()
    {
        graphic = GetComponent<SpriteRenderer>();

    }

    public ItemObject Copy(ItemObject itemObject)
    {

        Set(itemObject.itemInfo);

        return this;
    }

    public void Set(ItemInfo itemInfo)
    {

        this.itemInfo = itemInfo.Copy();
        graphic.sprite = itemInfo.getSprite();
        
 

    }


    public ItemObject Clon()
    {


        return (ItemObject)this.MemberwiseClone();

    }

    private void Join()
    {

        ItemManager itemManager = ItemManager.GetInstatnce();
        
        itemManager.Join(itemInfo.getUqName(),this);

    }




}