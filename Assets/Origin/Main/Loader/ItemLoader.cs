using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ItemLoader : Loader
{

    private const string LABEL = "label";
    private const string DESCRIPTION = "description";
    private const string STUFFCATEGORIES = "stuffCategories";

    private const string GRAPHICDATA = "graphicData";
    private const string GRAPHICCLASS = "graphicClass";
    private const string TEXPATH = "texPath";

    private const string RARE = "rare";
    private const string AMOUNT = "amount";


    public override void Load(string path, XmlNodeList nodeList)
    {

        /*item type에 따라 받는 xml을 달리 하면 될거 같은데.*/

        string modName = nodeList.Item(0).ParentNode.Attributes[MODNAME].Value;
        int index = path.IndexOf(modName) + modName.Length + 1;
        string modPath = path.Substring(0, index);
        
        try
        {
            foreach (XmlNode node in nodeList)
            {


                string itemThingDefName = node.Attributes[PARENTNAME].Value;

                string itemDefName = node.SelectSingleNode(DEFNAME).InnerText;
                string itemDecription = node.SelectSingleNode(LABEL).InnerText;

                XmlNode graphicDef = node.SelectSingleNode(GRAPHICDATA);
                string graphicDir = graphicDef.SelectSingleNode(TEXPATH).InnerText;
                graphicDir = modPath + graphicDir;
                string graphicType = graphicDef.SelectSingleNode(GRAPHICCLASS).InnerText;


                string label = node.SelectSingleNode(LABEL).InnerText;
                string decripton = node.SelectSingleNode(DESCRIPTION).InnerText;
                string stuffCategories = node.SelectSingleNode(STUFFCATEGORIES).InnerText;
                double rare = double.Parse(node.SelectSingleNode(RARE).InnerText);
                int amount = int.Parse(node.SelectSingleNode(AMOUNT).InnerText);

                Debug.Log("고유 이름 " + modName);
                Debug.Log("아이템 이름 " + itemDefName);
                Debug.Log("아이템 라벨 " + label);
                Debug.Log("아이템 설명 " + decripton);
                Debug.Log("그래픽 경로 " + graphicDir);
                Debug.Log("그래픽 타입 " + graphicType);
                Debug.Log("레어도" + rare);
                Debug.Log("갯수 " + amount);

                //    print("아이템 카테고리" + label.InnerText);
                Debug.Log("아이템 제작 중");
                ItemInfo item = new ItemInfo();
                item.setDecription(decripton).setDefName(itemDefName).setUqName(itemThingDefName).setLabel(label).setGrapic(graphicDir, graphicType).setAmount(amount).setRare(rare);

                ItemDcitionary.instance.AddItem(item);
                //ItemManager.GetInstatnce().Make(item);


            }

        }
        catch (Exception e)
        {
            Debug.Log("Item Loading 오류문제: " + e);

        }
    }
}
