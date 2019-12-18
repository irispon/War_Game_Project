﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T:SingletonObject<T>
{
    /// <summary>
    /// T는 상속받는 클래스의 이름을 작성해주시면 됩니다.
    /// </summary>
    public static T instance { get; private set; } = null;

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance =this as T;
        }
        else
        {
            Destroy(gameObject);
        }
      //  DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}