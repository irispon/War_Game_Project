using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ModListLoader:Loader
{

    public static List<String> MODLIST;

   public List<String> ModList { get; private set; }

    public override void Load(string path ,XmlNodeList nodeList)
    {
        List<String> modPaths = new List<string>();
        MODLIST = new List<string>();
        MODLIST.Clear();
        try
        {
            foreach (XmlNode node in nodeList)
            {
                MODLIST.Add(node.SelectSingleNode("ModName").InnerText);
                Debug.Log("모드 리스트 테스트"+node.SelectSingleNode("ModName").InnerText);
                modPaths.Add(node.LastChild.InnerText);
            }

        }
        catch (Exception e)
        {
            Debug.Log("모드 List 로딩 에러" + e);

        }


        if (modPaths.Count >= 1)
        {
            try
            {
                foreach (string modpath in modPaths)
                {
                    Debug.Log("코어는?" + modpath);
                   XMLManager.Load(modpath + MODINFOPATH, new XMLManager.XmlLoad(new ModInfoLoader().Load));

                }

            }
            catch (Exception e)
            {
                Debug.Log("모드 Info 로딩 에러" + e);

            }


        }


    }
}
