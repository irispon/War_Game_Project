using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    float Attack(ITargetAble target);//return 데미지=>투사체, 히트 스캔, 등등
  
}
