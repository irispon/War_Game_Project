using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonObject<DataManager>
{
    /*추후 데이터 연동. 현재는 임시 데이터를 저장하고 있는 객체 */
    // Start is called before the first frame update
    private WDictionary<Category, ILoadManager> loadManagers = new WDictionary<Category, ILoadManager>();

    void Start()
    {
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public T Find<T>(string uqName) where T:struct,IObjectInfo
    {
        T t = new T();


        try
        {

            return (T)loadManagers[t.GetCategory()].Find(uqName);
        }
        catch (Exception e)
        {
            Debug.Log("해당 ID " + "'" + uqName + "'" + " 를 찾을 수 없거나 오류가 존재합니다." + e);
            return default(T);

        }



    }

    public List<IObjectInfo> FindInfos(Category category) 
    {

        return loadManagers[category].GetDatas();



    }



    public void join(IObjectInfo iObjectInfo,ILoadManager loadManager)
    {
        loadManagers.Add(iObjectInfo.GetCategory(), loadManager);

    }
    void Load()
    {


    }

    

}
