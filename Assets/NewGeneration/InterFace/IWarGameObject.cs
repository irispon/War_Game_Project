using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarGameObject:ITargetAble
{

    void Draw();
    void Move();
    void GetDamage(int damage);
    IObjectInfo GetData();



}
