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


        string tag = nodeList[0].InnerText;
        Debug.Log("카테고리 확인" + tag);

        switch (tag)
        {
            case Organ.CATAGORY:
                OrganLoad(path, nodeList);
                break;


        }



    }


    private void OrganLoad(string path,XmlNodeList nodeList)
    {

        Organs organs = Organs.GetInstance();
        for (int i = 1; i < nodeList.Count; i++)
        {
            Organ organ = new Organ();
            XmlNode node = nodeList[i];
            Parts part=organ.parts;
            string ThingDefName = node.Attributes[PARENTNAME].Value;
            string defName = node.SelectSingleNode(Organ.DEFNAME).InnerText;
          
            bool necessary= organ.necessary;
            int durable=organ.durable;
            float efficiency = organ.efficiency;

            try
            {           
                
                durable = int.Parse(node.SelectSingleNode(Organ.DURABLE).InnerText);
                part = EnumUtills.Parse<Parts>(node.SelectSingleNode(Organ.PART).InnerText);
                efficiency = float.Parse(node.SelectSingleNode(Organ.EFFICIENCY).InnerText);
                if (node.SelectSingleNode(Organ.NECESSARY) != null)
                {
                    necessary = BoolParser.Parse(node.SelectSingleNode(Organ.NECESSARY).InnerText);
                    Debug.Log(necessary);
                }
                else
                {
                    necessary = false;

                }
                    
            }
            catch(Exception e)
            {
                Debug.Log("OrganLoadError: "+"parsing 실패 "+e);

            }
            organ.uqName = ThingDefName;
            organ.name = defName;
            organ.necessary = necessary;
            organ.durable = durable;
            organ.parts = part;
            organ.efficiency = efficiency;

            Debug.Log("xml 노드 확인: " + ThingDefName);

            organs.addOrgan(organ);
        }

    }
}
