using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ArmorData
{
    public BodyParts parts;
    public string uniqName;
    public string name;
    public float def;
    public float block;//확률. 중첩될 수록 줄어듬
    public float reduction;
    public float durable;
}
