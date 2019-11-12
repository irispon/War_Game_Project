using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Load : MonoBehaviour
{

    //모드 목록
    private List<String> modPaths = new List<string>();
    //모드 아이템 폴더 경로


    // Start is called before the first frame update
    private XMLManager xMLManager = new XMLManager();
    public GameObject itemManager;


    void Awake()
    {
        if (ItemManager.GetInstatnce() == null)
        {
            Instantiate(itemManager);
        }

        xMLManager.Load(XMLManager.ModList.MODLISTDIR, new XMLManager.XmlLoad(LoadModList) );

    }

    private void LoadModList(String path, XmlNodeList nodeList)/*모드의 리스트를 받는 xml입니다.*/
    {

        /*내부 xml string*/


        try
        {
            foreach (XmlNode node in nodeList)
            {

              
                print("모드 주소" + node.SelectSingleNode(XMLManager.ModList.MODDIR).InnerText);
                
                modPaths.Add(node.LastChild.InnerText);
            }

        }catch(Exception e)
        {
            Debug.Log("모드 List 로딩 에러"+e);
          
        }

        print("모드 리스트 로딩 완료");

        if (modPaths.Count>=1)
        {
            try
            {
                foreach (string modpath in modPaths)
                {
                    xMLManager.Load(modpath + XMLManager.ModInfo.MODINFOPATH, new XMLManager.XmlLoad(LoadModInfo));
                    
                }

            }
            catch (Exception e)
            {
                Debug.Log("모드 Info 로딩 에러" + e);

            }


        }



    }


    private void LoadModInfo(String path,XmlNodeList nodeList)
    {
        List<String> Items = new List<string>();

        try
        {
            foreach (XmlNode node in nodeList)
            {
                

                if (!node.SelectSingleNode(XMLManager.ModInfo.ITEMS).InnerText.Equals("False"))
                {
                    XmlNodeList itemDir = node.SelectNodes(XMLManager.ModInfo.ITEMS);
                    foreach (XmlNode itemNode in itemDir)
                    {
                        print("아이템 주소" + itemNode.InnerText);
                        Items.Add(itemNode.InnerText);

                    }

                }


                if (node.SelectSingleNode(XMLManager.ModInfo.SCRIPTS).InnerText.Equals("True"))
                {
                    Debug.Log("Scripts true");

                }
                else
                {
                    Debug.Log("Scripts false");
                }

                if (node.SelectSingleNode(XMLManager.ModInfo.OTHERTING).InnerText.Equals("True"))
                {
                    Debug.Log("OtherThing true");


                }
                else
                {
                    Debug.Log("OtherThing false");

                }



            }


            if (Items.Count >= 1)
            {
                foreach (string itemDir in Items)
                {

                   print(path.Replace(XMLManager.ModInfo.MODINFOPATH,itemDir));
                   xMLManager.Load(path.Replace(XMLManager.ModInfo.MODINFOPATH, itemDir),new XMLManager.XmlLoad(LoadItem));
                }

            }

        }
        catch (Exception e)
        {
            Debug.Log("모드 List 로딩 에러" + e);

        }


        {



        }


    }


    private void LoadItem(String path, XmlNodeList nodeList)
    {

        String modName = nodeList.Item(0).ParentNode.Attributes[XMLManager.ItemInfo.MODNAME].Value;
        int index = path.IndexOf(modName)+modName.Length+1;
        String modPath = path.Substring(0,index);

        try
        {
            foreach (XmlNode node in nodeList)
            {

              
                String itemThingDefName = node.Attributes[XMLManager.ItemInfo.PARENTNAME].Value;
 
                String itemDefName = node.SelectSingleNode(XMLManager.ItemInfo.DEFNAME).InnerText;
                String itemDecription = node.SelectSingleNode(XMLManager.ItemInfo.DESCRIPTION).InnerText;

                XmlNode graphicDef = node.SelectSingleNode(XMLManager.ItemInfo.GRAPHICDATA);
                String graphicDir = graphicDef.SelectSingleNode(XMLManager.ItemInfo.GraphicData.TEXPATH).InnerText;
                graphicDir = modPath + graphicDir;
                String graphicType = graphicDef.SelectSingleNode(XMLManager.ItemInfo.GraphicData.GRAPHICCLASS).InnerText;


                String label = node.SelectSingleNode(XMLManager.ItemInfo.LABEL).InnerText;
                String decripton = node.SelectSingleNode(XMLManager.ItemInfo.DESCRIPTION).InnerText;
                String stuffCategories = node.SelectSingleNode(XMLManager.ItemInfo.STUFFCATEGORIES).InnerText;

   
                Debug.Log("고유 이름 "   + modName);
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
            Debug.Log("Item Loading 오류문제: "+e);

        }



    }


  

    }


