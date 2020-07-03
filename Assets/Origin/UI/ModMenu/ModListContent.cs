using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModListContent : SingletonObject<ModListContent>
{
    List<ModInfo> modListInfos;

    public void Start()
    {
        modListInfos = new List<ModInfo>();
    }


    public void Save()
    {
        modListInfos.Clear();
        Debug.Log(transform.childCount);
        XmlDocument doc = new XmlDocument();
        XmlNode modList = doc.CreateElement("ModList");


        doc.AppendChild(modList);


        for (int i = 0; i < transform.childCount; i++)
        {
            ModInfo info = transform.GetChild(i).GetComponent<ContentManager>().info;
            Debug.Log("이름 확인" + info.name);
            Debug.Log("주소 확인"+info.directory);

            XmlNode modInfo = doc.CreateElement("ModInfo");
            XmlElement modName = doc.CreateElement("ModName");
            XmlElement moDir = doc.CreateElement("MoDir");
            modName.InnerText = info.name;
            moDir.InnerText = info.directory;


            modList.AppendChild(modInfo);
            modInfo.AppendChild(modName);
            modInfo.AppendChild(moDir);

        }

        doc.Save(XMLManager.ModList.MODLISTDIR);
    }


}
