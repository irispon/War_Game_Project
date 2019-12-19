using System;
using UnityEngine;

public class ItemObject: MonoBehaviour
{

   
    public ItemInfo itemInfo;
    private SpriteRenderer graphic;


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

       // this.itemInfo = itemInfo.Copy();
        name = itemInfo.getDefName();
        graphic.sprite = itemInfo.getSprite();
        
 

    }

    public ItemObject Clon()
    {


        return (ItemObject)this.MemberwiseClone();

    }






}