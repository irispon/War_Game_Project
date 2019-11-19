using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ModInfoLoader : Loader
{
    private const string ITEMS = "Items";// /*xml tag*/
    private const  string FIELDS = "Fields"; /*xml tag*/
    private const  string SCRIPTS = "Scripts"; /*xml tag*/ //true or false 
    private const  string OTHERTING = "OtherThing"; /*xml tag*/ //true or false 

    private string path;

    public override void Load(string path,XmlNodeList nodeList)
    {

        /*이 부분에서 수정이 필요할 것 같음.*/

        this.path = path;
        List<String> Items = new List<string>();
        List<String> fields = new List<string>();

        try
        {
            foreach (XmlNode node in nodeList)
            {


                if (!node.SelectSingleNode(ITEMS).InnerText.Equals("False"))
                {
                    XmlNodeList itemDir = node.SelectNodes(ITEMS);
                    foreach (XmlNode itemNode in itemDir)
                    {
                        Debug.Log("주소" + itemNode.InnerText);
                        Items.Add(itemNode.InnerText);

                    }

                }

                if (!node.SelectSingleNode(FIELDS).InnerText.Equals("False"))
                {
                    XmlNodeList fieldDir = node.SelectNodes(FIELDS);
                    foreach (XmlNode fieldNode in fieldDir)
                    {
                        Debug.Log("타일 주소" + fieldNode.InnerText);
                        fields.Add(fieldNode.InnerText);

                    }

                }


                if (node.SelectSingleNode(SCRIPTS).InnerText.Equals("True"))
                {
                    Debug.Log("Scripts true");

                }
                else
                {
                    Debug.Log("Scripts false");
                }

                if (node.SelectSingleNode(OTHERTING).InnerText.Equals("True"))
                {
                    Debug.Log("OtherThing true");


                }
                else
                {
                    Debug.Log("OtherThing false");

                }



            }

            Debug.Log("item 로딩 에러");
            try
            {
                LoadObject(Items, new ItemLoader());
            }
            catch (Exception e)
            {
                Debug.Log("item 로딩 에러");
            }
            
           
            LoadObject(fields, new TileLoader());


        }
        catch (Exception e)
        {
            Debug.Log("모드 List 로딩 에러" + e);

        }


        {



        }
    }


    private void LoadObject(List<string> dirs, Loader loader)
    {
        if (dirs.Count >= 1)
        {
            foreach (string dir in dirs)
            {

                Debug.Log(path.Replace(MODINFOPATH, dir));
                XMLManager.Load(path.Replace(MODINFOPATH, dir), new XMLManager.XmlLoad(loader.Load));
            }

        }

    }
}
