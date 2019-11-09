using System;
using UnityEngine;

public class ItemObject: MonoBehaviour
{
    private ItemInfo itemInfo;
    private SpriteRenderer graphic;


    public void Make(ItemInfo itemInfo)
    {
        graphic = GetComponent<SpriteRenderer>();
        Set(itemInfo);
        this.Join();

    }

    private void Awake()
    {


    }

    public void Set(ItemInfo itemInfo)
    {

        this.itemInfo = itemInfo.Copy();
        graphic.sprite= SpriteLoader.LoadNewSprite(itemInfo.getGrapicPath());
      
 

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