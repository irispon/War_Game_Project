using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ModLoader
{
    private const string MODLISTDIR = "./ModList/ModList.xml";

    public void Load()
    {

      
        XMLManager.Load(MODLISTDIR, new XMLManager.XmlLoad(new ModListLoader().Load));
    }
}
