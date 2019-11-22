using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TileLoader : Loader
{
    public override void Load(string path, XmlNodeList nodeList)
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
                    fieldProperty.name = node.SelectSingleNode(XMLManager.Field.DEFNAME).InnerText;

                    fieldProperty.rare = double.Parse(node.SelectSingleNode(XMLManager.Field.RARE).InnerText);
                    fieldProperty.disturbanceDegree = double.Parse(node.SelectSingleNode(XMLManager.Field.DISTURBANCEDEGREE).InnerText);

                    try
                    {
                        String[] sprites = node.SelectSingleNode(XMLManager.Field.TEXPATH).InnerText.Split(',');

                        foreach (String sprite in sprites)
                        {

                            fieldProperty.addSprite(modPath + sprite);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log("텍스쳐 로딩 실패" + e);

                    }



                    fieldProperty.type = EnumUtills.Parse<Layer>(node.SelectSingleNode(XMLManager.Field.TYPE).InnerText);


                }
                catch (Exception e)
                {
                    Debug.Log("타입 변경 실패" + e);

                }

                Debug.Log("고유 이름 " + fieldProperty.uqName);
                Debug.Log("타일 이름 " + fieldProperty.name);
                Debug.Log("타일 희귀도 " + fieldProperty.rare);
                Debug.Log("타일 레이어 " + fieldProperty.type);
                Debug.Log("타일 방해도 " + fieldProperty.disturbanceDegree);

                TileManager.getInstance().addProperty(fieldProperty);


            }

        }
        catch (Exception e)
        {
            Debug.Log("field Loading 오류문제: " + e);

        }



       
    }
}
