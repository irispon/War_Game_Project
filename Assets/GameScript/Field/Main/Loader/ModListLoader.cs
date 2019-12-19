using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ModListLoader:Loader
{
   

    public override void Load(string path ,XmlNodeList nodeList)
    {
        List<String> modPaths = new List<string>();
        try
        {
            foreach (XmlNode node in nodeList)
            {

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
