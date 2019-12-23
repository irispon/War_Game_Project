using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class ModCrwaler : SingletonObjectSlave<ModCrwaler>
{
    public string PATH { get; private set; }= "./Assets/Mod";
    private string FileName = "Introduction.xml";
    public List<ModInfo> infoes { get; private set; }
    public List<String> modList { get; private set; }
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        infoes = new List<ModInfo>(30);
        modList = ModListLoader.MODLIST;

    }

    public void GetMods()
    {

        Load(PATH);
        MainViewManager.instance.OpenModMenu();
    }
    
    void Start()
    {

       
    }

    private void Load(string path)
    {
        infoes.Clear();
        DirectoryInfo modDirectory = new DirectoryInfo(@path);
        DirectoryInfo[] subDirectorires = modDirectory.GetDirectories();
        foreach(DirectoryInfo subDirectory in subDirectorires)
        {
            try
            {
                string fullPath = subDirectory.GetFiles(FileName)[0].FullName;
                if (fullPath != null)
                {
                    Debug.Log(fullPath);
                    XMLManager.Load(fullPath, new XMLManager.XmlLoad(Load));
                }
         
            }
            catch(Exception e)
            {

            }
            

        }

    }

    private void Load(string path, XmlNodeList nodeList)
    {
        ModInfo info = new ModInfo();
        Debug.Log("시작");
        foreach (XmlNode node in nodeList)
        {
 
            info.name = node.SelectSingleNode(ModInfo.NAME).InnerText;
            Debug.Log(info.name);
            info.directory = path;
            try
            {
                if (BoolParser.isBool(node.SelectSingleNode(ModInfo.NECESSARYMODE).InnerText) == false)
                {
                    info.necessaryMode = node.SelectSingleNode(ModInfo.NECESSARYMODE).InnerText.Split(',');
                }
            }
            catch (Exception e)
            {
               
            }

            info.describe = node.SelectSingleNode(ModInfo.DESCRIBE).InnerText;
            info.subdescribe = node.SelectSingleNode(ModInfo.SUBDESCRIBE).InnerText;
            
            Debug.Log(info.name);
            Debug.Log(info.describe);
            Debug.Log(info.subdescribe);
            infoes.Add(info);
            

        }


    }
}

