using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObjectSlave<T>: MonoBehaviour, Initable where T : SingletonObjectSlave<T>
{

    public static T instance { get; private set; }


    public void Init()
    {
        instance = null;
        Destroy(gameObject);
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        ObjectManager.GetInstance().AddDontSingletoneObject(this);
    }
}
