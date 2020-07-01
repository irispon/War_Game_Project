using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadManager
{
    void Load();
    IObjectInfo Find(string uqName);
    List<IObjectInfo> GetDatas();
}
