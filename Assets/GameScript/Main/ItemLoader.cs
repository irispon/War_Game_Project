using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ItemLoader : Loader
{
    public override void Load(string path, XmlNodeList nodeList)
    {

        /*item type에 따라 받는 xml을 달리 하면 될거 같은데.*/

        string modName = nodeList.Item(0).ParentNode.Attributes[XMLManager.ItemInfo.MODNAME].Value;
        int index = path.IndexOf(modName) + modName.Length + 1;
        string modPath = path.Substring(0, index);
        
        try
        {
            foreach (XmlNode node in nodeList)
            {


                string itemThingDefName = node.Attributes[XMLManager.ItemInfo.PARENTNAME].Value;

                string itemDefName = node.SelectSingleNode(XMLManager.ItemInfo.DEFNAME).InnerText;
                string itemDecription = node.SelectSingleNode(XMLManager.ItemInfo.DESCRIPTION).InnerText;

                XmlNode graphicDef = node.SelectSingleNode(XMLManager.ItemInfo.GRAPHICDATA);
                string graphicDir = graphicDef.SelectSingleNode(XMLManager.ItemInfo.GraphicData.TEXPATH).InnerText;
                graphicDir = modPath + graphicDir;
                string graphicType = graphicDef.SelectSingleNode(XMLManager.ItemInfo.GraphicData.GRAPHICCLASS).InnerText;


                string label = node.SelectSingleNode(XMLManager.ItemInfo.LABEL).InnerText;
                string decripton = node.SelectSingleNode(XMLManager.ItemInfo.DESCRIPTION).InnerText;
                string stuffCategories = node.SelectSingleNode(XMLManager.ItemInfo.STUFFCATEGORIES).InnerText;


                Debug.Log("고유 이름 " + modName);
                Debug.Log("아이템 이름 " + itemDefName);
                Debug.Log("아이템 라벨 " + label);
                Debug.Log("아이템 설명 " + decripton);
                Debug.Log("그래픽 경로 " + graphicDir);
                Debug.Log("그래픽 타입 " + graphicType);

                //    print("아이템 카테고리" + label.InnerText);
                Debug.Log("아이템 제작 중");
                ItemInfo item = new ItemInfo();
                item.setDecription(decripton).setDefName(itemDefName).setUqName(itemThingDefName).setLabel(label).setGrapic(graphicDir, graphicType);

                ItemManager.GetInstatnce().Make(item);


            }

        }
        catch (Exception e)
        {
            Debug.Log("Item Loading 오류문제: " + e);

        }
    }
}
