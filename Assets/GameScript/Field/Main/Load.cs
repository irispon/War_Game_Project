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


    void Awake()
    {
      
        modPaths = new List<string>(); 
        new ModLoader().Load();


    }


    }


