using System.Collections.Generic;
using UnityEngine;

public struct WarGameUnitData:IObjectInfo
{
   

    public string unitName;
    public string uniqName;


    public float hp;//체력 최대치
    public WDictionary<BodyParts,WeaponData> weapon;// atk => to Weapon으로 변경
    public WDictionary<BodyParts, ArmorData> armorDatas;
    public float sh;//일단 보류
    public float sp;//마나
    public float stamina;//기력(미션을 나가면 소모됨)
    public float dodge;//회피율

    public WarGameUnitGhraphic warGameUnitGhraphic;

    public Category GetCategory()
    {
        return Category.Unit;
    }

    public string GetName()
    {
        return unitName;
    }

    public IManager GetParent()
    {
        return UnitMaster.GetInstance();
    }

    public Sprite GetSprite()
    {
        return warGameUnitGhraphic.Forward.sprite;
    }

    public string GetUqName()
    {
        return uniqName;
    }

}

public struct WarGameUnitGhraphic
{
    //애니메이션 전용 클래스 만들어야할 듯
    public GameSprite Idle;
    public GameSprite Forward;
    public GameSprite Back;
    public GameSprite Left;
    public GameSprite Right;

}

public struct GameSprite
{
    public Sprite sprite;
    public State state;

}

public enum State
{
    Idle,Forward,Back,Left,Right

}