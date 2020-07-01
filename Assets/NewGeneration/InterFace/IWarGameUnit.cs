using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarGameUnit : IWarGameObject,ICharacterGraphic
{
     void Join(IObjectInfo unitData);
     void SetUnitData(IObjectInfo unitData);
     WarGameUnitData GetUnitData(WarGameUnitData unitData);
}
