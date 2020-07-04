using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MapForm 
{
    public string formName;
    public Terrain[] terrains;
    public int level;
    // 추후 레벨 디테일 추가(몬스터 정도, 입구는 얼마나 등등)

}
