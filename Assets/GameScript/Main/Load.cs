using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Load : MonoBehaviour
{

    //모드 목록
    private const string MODLISTDIR = "./ModList/ModList.xml";
    private const string MODDIR = "MoDir"; /*xml tag*/
    private List<String> modPaths;


    public GameObject[] Managers;
    public GameObject fieldManager;

    void Awake()
    {
      
        modPaths = new List<string>();
        foreach (GameObject manager in Managers)
        {
            
            Instantiate(manager);

        }

        new ModLoader().Load();
        Instantiate(fieldManager);



    }


    }


