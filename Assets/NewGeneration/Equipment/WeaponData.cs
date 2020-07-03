using System.Collections.Generic;
using UnityEngine;

public struct WeaponData:IObjectInfo
{
    public string name;
    public string uniqName;

    public MeleeWeaponData meleeWeaponData;
    public RangeWeaponData rangeWeaponData;

    public Category GetCategory()
    {
        return Category.Weapon;
    }

    public string GetName()
    {
        return name;
    }

    public IManager GetParent()
    {
        return null;
    }

    public Sprite GetSprite()
    {
        return null;
    }

    public string GetUqName()
    {
        return uniqName;
    }


}


public struct MeleeWeaponData
{

    public Sprite sprite;
    public List<Damage> damages;
    public float delay;


    public float range;//무기 사거리
    public float scope;
    public int splash;

}

public struct RangeWeaponData
{
    public List<string> projectile; //사용 가능한 projectile 목록


    public Projectile setProjectile;
    public RangeWeaponType rangeWeaponType;


    public float shotPower;
    public float acuuracy;//해당 원거리 무기가 주는 정확도 보정치
    public float delay;
    public float burst;
    public float burstDelay;

}

public struct Projectile
{
    public string name;
    public string uniqName;
    public Damage damage;
    public Explosion explosion;


}

public struct Damage
{
    DamageType damageType;
    public float damage;
    public float acuuracy;//근접일 시에 정확도, 투사체일 시에는 정확도 보정치
    public StatePhase phase;
}

public struct Explosion
{
    public float scope;
    public float power;//power가 쎌 수록 데미지 편차가 적음 100 최대
    public Damage damage;

}



public enum WeaponType
{
    Range,Melee

}

public enum AttackType
{
    HitScan, Projectile

}

public enum DamageType
{
    Magic,Blunt,Cut, Pearcing

}
public enum RangeWeaponType
{
    light,medium,heavy//힘보정(요구치 존재 하지만 특정 타입의 투사체를 사용할 때 무기 타입에 따라 패털티가 존재함)
}


