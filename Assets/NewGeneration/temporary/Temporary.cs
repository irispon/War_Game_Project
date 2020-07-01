using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary 
{
    public List<WarGameUnitData> CharData()
    {
        List<WarGameUnitData> unitdatas;
        unitdatas = new List<WarGameUnitData>();
        WarGameUnitData data=new WarGameUnitData ();
        data.uniqName = "Sera";
        data.unitName = "서라";

        GameSprite sprite;
       
        sprite.sprite = SpriteLoader.LoadNewSprite("Assets/NewGeneration/temporary/Left.png",100.0f);
        
        sprite.state = State.Left;
        data.warGameUnitGhraphic.Left = sprite;

        sprite.sprite = SpriteLoader.LoadNewSprite("Assets/NewGeneration/temporary/Right.png", 100.0f);
        sprite.state = State.Right;
        data.warGameUnitGhraphic.Right = sprite;

        sprite.sprite = SpriteLoader.LoadNewSprite("Assets/NewGeneration/temporary/Left.png", 100.0f);
        sprite.state = State.Forward;
        data.warGameUnitGhraphic.Forward = sprite;

        data.hp = 100;
        data.sh = 10;
        data.stamina = 20;
        data.sp = 50;
        data.dodge = 10;


        WeaponData weaponData;
        weaponData.uniqName = "대검";

        ArmorData armorData;
        armorData.uniqName = "플레이트갑옷";

       

        unitdatas.Add(data);

        data.uniqName = "Rine";
        data.unitName = "라인";

        unitdatas.Add(data);

        return unitdatas;
    }
}
