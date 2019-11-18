using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public abstract class Loader : Loadable
{

    protected const string MODNAME = "ModName";
    protected const string MODINFOPATH = "/ModInfo/ModInfo.xml"; /*xml tag*/

    protected XMLManager xmlManager;
    public Loader()
    {
        xmlManager = new XMLManager();
    }
    public abstract void Load(string path,XmlNodeList nodeList);



}
