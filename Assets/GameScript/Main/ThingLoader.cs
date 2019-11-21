using System;
using System.Xml;
using UnityEngine;

public class ThingLoader :Loader
{
    private const string catagory = "catagory";

    /* organ xml form*/



    enum Catagory
    {
        Organ,Race

    }
   

    
    public override void Load(string path, XmlNodeList nodeList)
    {

        Debug.Log("카테고리 확인" + nodeList[0].InnerText);
      




    }


    private void OrganLoad(string path,XmlNodeList nodeList)
    {

        for (int i = 1; i < nodeList.Count; i++)
        {
            XmlNode node = nodeList[i];
            string ThingDefName = node.Attributes[PARENTNAME].Value;
            string defName = node.SelectSingleNode(Organ.DEFNAME).InnerText;
            string part = node.SelectSingleNode(Organ.PART).InnerText;
            try
            {            
                int durable = int.Parse(node.SelectSingleNode(Organ.DURABLE).InnerText);
                bool necessary = bool.Parse(node.SelectSingleNode(Organ.NECESSARY).InnerText);
            }
            catch(Exception e)
            {
                Debug.Log("OrganLoadError: "+"parsing 실패 "+e);

            }

       



            Debug.Log("xml 노드 확인: " + ThingDefName);

        }

    }
}
