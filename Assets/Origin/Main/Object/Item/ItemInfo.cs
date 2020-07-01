using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo:IObjectInfo
{

    /*폼 변경을 넣어야 될 듯.*/
    private string uniqueName;/*일단은 필요 없는 부분일 듯*/
    private string defName="이름없음";
    private string label="";
    private string description="설명 없음";
    private ItemType itemType = ItemType.Item;
    public Layer layer { get; } = Layer.Item;
    /*그래픽; 관련. 추후 타입을 스프라이트로 변경. 그래픽 타입은 enum으로 만들어서 single double 등등 으로 변경 예정*/
    private string grapicPath="";
    private string grapicType="";
    private Sprite sprite;
    public double rare { private set; get; } = -1;
    public int amount { private set; get; } = -1;


    public ItemInfo setRare(double rare)
    {
        this.rare = rare;

        return this;
    }

    public ItemInfo setAmount(int amount)
    {
        this.amount = amount;

        return this;
    }


    public ItemInfo setUqName(string name)
    {
        uniqueName = name;

        return this;
    }
    public ItemInfo setitemType(ItemType itemType)
    {
        this.itemType = itemType;

        return this;
    }
    public ItemInfo setDefName(string name)
    {
        defName = name;

        return this;
    }

    public ItemInfo setLabel(string label)
    {
        this.label = label;

        return this;
    }

    public ItemInfo setDecription(string descript)
    {
        description = descript;

        return this;
    }

    public ItemInfo setGrapic(string path, string type)
    {
        grapicPath = path;
        sprite = SpriteLoader.LoadNewSprite(grapicPath);
        
        grapicType = type;

        return this;
    }

    public string getUqName()
    {


        return uniqueName;

    }

    public string getDefName()
    {

        return defName;
    }

    public string getLabel()
    {

        return label;
    }

    public string getDecription()
    {

        return description;
    }

    public Sprite getSprite()
    {

        return sprite;
    }

    public string getGrapicPath()
    {

        return grapicPath;
    }

    public string getGrapicType()
    {

        return grapicType;
    }


    public ItemType getItemType()
    {

        return itemType;
    }
    public ItemInfo Copy()
    {

        return (ItemInfo)this.MemberwiseClone();
    }

    public void make()
    {
     

    }

    public string GetName()
    {
        return defName;
    }

    public string GetUqName()
    {
        return uniqueName;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Category GetCategory()
    {
        return Category.Item;
    }

    public IManager GetParent()
    {
        return ItemDcitionary.instance;
    }
}
