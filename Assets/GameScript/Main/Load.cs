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
    public GameObject[] Managers;
    public GameObject fieldManager;

    void Awake()
    {

        foreach (GameObject manager in Managers)
        {
            Instantiate(manager);

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
        List<String> fields = new List<string>();

        try
        {
            foreach (XmlNode node in nodeList)
            {
                

                if (!node.SelectSingleNode(XMLManager.ModInfo.ITEMS).InnerText.Equals("False"))
                {
                    XmlNodeList itemDir = node.SelectNodes(XMLManager.ModInfo.ITEMS);
                    foreach (XmlNode itemNode in itemDir)
                    {
                        print("주소" + itemNode.InnerText);
                        Items.Add(itemNode.InnerText);

                    }

                }

                if (!node.SelectSingleNode(XMLManager.ModInfo.FIELDS).InnerText.Equals("False"))
                {
                    XmlNodeList fieldDir = node.SelectNodes(XMLManager.ModInfo.FIELDS);
                    foreach (XmlNode fieldNode in fieldDir)
                    {
                        print("타일 주소" + fieldNode.InnerText);
                        fields.Add(fieldNode.InnerText);

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


            if (fields.Count >= 1)
            {
                foreach (string fieldDir in fields)
                {

                    print(path.Replace(XMLManager.ModInfo.MODINFOPATH, fieldDir));
                    xMLManager.Load(path.Replace(XMLManager.ModInfo.MODINFOPATH, fieldDir), new XMLManager.XmlLoad(LoadField));
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


    private void LoadField(String path, XmlNodeList nodeList)
    {
        String modName = nodeList.Item(0).ParentNode.Attributes[XMLManager.ItemInfo.MODNAME].Value;
        int index = path.IndexOf(modName) + modName.Length + 1;
        String modPath = path.Substring(0, index);



        try
        {
            foreach (XmlNode node in nodeList)
            {
                FieldProperty fieldProperty = new FieldProperty();
                try
                {
               
                    fieldProperty.uqName = node.Attributes[XMLManager.Field.PARENTNAME].Value;
                    fieldProperty.name =  node.SelectSingleNode(XMLManager.Field.DEFNAME).InnerText;

                    fieldProperty.rare = double.Parse(node.SelectSingleNode(XMLManager.Field.RARE).InnerText);
                    fieldProperty.disturbanceDegree = double.Parse(node.SelectSingleNode(XMLManager.Field.DISTURBANCEDEGREE).InnerText);

                    try
                    {
                        String[] sprites = node.SelectSingleNode(XMLManager.Field.TEXPATH).InnerText.Split(',');

                        foreach(String sprite in sprites)
                        {   

                            fieldProperty.addSprite(modPath+sprite);
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.Log("텍스쳐 로딩 실패" +e);

                    }

                   
            
                    fieldProperty.type = FieldProperty.Parse(node.SelectSingleNode(XMLManager.Field.TYPE).InnerText);


                }
                catch(Exception e)
                {
                    Debug.Log("타입 변경 실패"+e);

                }
      
                Debug.Log("고유 이름 " + fieldProperty.uqName);
                Debug.Log("타일 이름 " + fieldProperty.name);
                Debug.Log("타일 희귀도 " + fieldProperty.rare);
                Debug.Log("타일 레이어 " + fieldProperty.type);
                Debug.Log("타일 방해도 " + fieldProperty.disturbanceDegree);

                FloorManager.getInstance().addProperty(fieldProperty);


            }

        }
        catch (Exception e)
        {
            Debug.Log("field Loading 오류문제: " + e);

        }



        Instantiate(fieldManager);


    }


  

    }


