using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class LoadManager<T,Data> : ILoadManager where T : class,ILoadManager, new() where Data:IObjectInfo, new()
{

    /*미 완성 new T()로 쓰지 마세요*/

    protected WDictionary<string, Data> dataManager;
    
    private static System.Object lockObj = new System.Object();
    protected static T instance = null;
    public static T GetInstance()
    {

        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new T();
                }
            }

        }


        return instance;
    }


    public LoadManager()
    {
        dataManager = new WDictionary<string, Data>();
        DataManager.GetInstance().join(new Data(), this);
        Load();


    }

    public virtual IObjectInfo Find(string uqName)
    {
        Debug.Log("" + dataManager[uqName].ToString());
        return dataManager[uqName];
    }




    public abstract void Load();

    public List<IObjectInfo> GetDatas()
    {
        List<Data> objectInfos = new List<Data>(dataManager.Values);

        return objectInfos.Cast<IObjectInfo>().ToList();
    }

}
