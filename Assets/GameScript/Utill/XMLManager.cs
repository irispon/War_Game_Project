using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;





/*xml 참고 양식 1. 분류: <Item>,<Character>,<ModList>) 

<모드 리스트 양식.>

<ModList>
    <ModInfo>
        <ModName>Core</ModName>
        <MoDir>./Mod/Core</MoDir>
    </ModInfo>
    <ModInfo>
        <ModName>Nore</ModName>
        <MoDir>./Mod/Nore</MoDir>
    </ModInfo>
</ModList>

<모드 정보 양식>

<ModInfomation>
    <ModInfo>
        <Items>/Items/Items.xml</Items>
        <Items>/Items/Weapon/Weapons.xml</Items>
        <Scripts>True</Scripts>
        <OtherThing>False</OtherThing>
    </ModInfo>
</ModInfomation>


    <아이템 정보 양식>

      <items ParentName ="Core">

		<ThingDef ParentName="BShirt">
            <defName>기본 셔츠</defName>
            <label>unfinished play</label>
            <description>기본 옷입니다.</description>
            <graphicData>
              <texPath>Texture/Shirts</texPath>
              <graphicClass>Graphic_Double</graphicClass>
            </graphicData>
            <stuffCategories Inherit="false" />
          </ThingDef>
		  
		  <ThingDef ParentName="AShirt">
            <defName>양본 셔츠</defName>
            <label>unfinished play</label>
            <description>양본 옷입니다.</description>
            <graphicData>
              <texPath>Texture/Shirts</texPath>
              <graphicClass>Graphic_Double</graphicClass>
            </graphicData>
            <stuffCategories Inherit="false" />
          </ThingDef>
		  
    </items>

 */


/*
 * 필드 xml 양식

   <fields ModName ="Core" >

    <ThingDef ParentName="Core_Dirt">
        <name>진흙</name>
        <disturbanceDegree>0.2</disturbanceDegree>
        <type>Floor</type>
        <rare>0.2</rare>
        <texPath>Texture/Shirts/Shirts.b.png, Texture/Shirts/Shirts.b.png </texPath>
      </ThingDef>

</fields>





 */



public class XMLManager
{

    public struct ModList
    {
        public static readonly string MODLISTDIR = "./ModList/ModList.xml";
        public static readonly string MODNAME = "ModName";/*xml tag*/
        public static readonly string MODDIR = "MoDir"; /*xml tag*/

    }

    public struct ModInfo
    {
        /*모드 정보 관련 상수 */
        public static readonly string MODINFOPATH = "/ModInfo/ModInfo.xml"; /*xml tag*/
        public static readonly string ITEMS = "Items";// /*xml tag*/
        public static readonly string FIELDS = "Fields"; /*xml tag*/
        public static readonly string SCRIPTS = "Scripts"; /*xml tag*/ //true or false 
        public static readonly string OTHERTING = "OtherThing"; /*xml tag*/ //true or false 

    }

    /*

    <ThingDef ParentName="BShirt">
        <defName>기본 셔츠</defName>
        <label>unfinished play</label>
        <description>기본 옷입니다.</description>
        <graphicData>
          <texPath>Texture/Shirts</texPath>
          <graphicClass>Graphic_Double</graphicClass>
        </graphicData>
        <stuffCategories Inherit="false" />
    </ThingDef>



     */

    public struct ItemInfo
    {
        /*아이템 관련 상수*/
        public static readonly string MODNAME = "ModName";
        public static readonly string PARENTNAME = "ParentName";
        public static readonly string DEFNAME = "defName";
        public static readonly string LABEL = "label";
        public static readonly string GRAPHICDATA = "graphicData";
        public struct GraphicData
        {

            public static readonly string GRAPHICCLASS = "graphicClass";
            public static readonly string TEXPATH = "texPath";
        }
        public static readonly string DESCRIPTION = "description";
        public static readonly string STUFFCATEGORIES = "stuffCategories";


    }

    public struct Field
    {
        /*아이템 관련 상수*/
        public static readonly string MODNAME = "ModName";
        public static readonly string PARENTNAME = "ParentName";
        public static readonly string DEFNAME = "name";
        public static readonly string DISTURBANCEDEGREE = "disturbanceDegree";
        public static readonly string TEXPATH = "texPath";
        public static readonly string RARE = "rare";
        public static readonly string TYPE = "type";


    }





    XmlDocument CreateXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        // Xml을 선언한다(xml의 버전과 인코딩 방식을 정해준다.)
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // 루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        XmlElement name = xmlDoc.CreateElement("Name");
        XmlElement lv = xmlDoc.CreateElement("Level");
        XmlElement exp = xmlDoc.CreateElement("Experience");
        exp.InnerText = "45";
        lv.InnerText = "1";
        name.InnerText = "wergia";


        xmlDoc.AppendChild(root).AppendChild(child);
        child.AppendChild(name);
        child.AppendChild(lv);
        child.AppendChild(exp);


        xmlDoc.Save("./Assets/XML/Character2.xml");

        return xmlDoc;
    }

    public static XmlNodeList Load(string path)
    {

        XmlDocument xmldoc = new XmlDocument();

        try
        {
            xmldoc.Load(path);
           
        }
        catch (Exception e)
        {
            Debug.Log("Load 오류 경로 설정 확인" + e);
            return null;
        }

        XmlElement root = xmldoc.DocumentElement;
        XmlNodeList nodes = root.ChildNodes;


        try
        {

            foreach(XmlNode node in nodes)
            {
               // Debug.Log(node.Name+" "+ node.InnerText);
              
            }

            /*xml 읽어올 수 있어야함.*/

            
        }
        catch (Exception e)
        {
            return null;
            Debug.Log("xml 노드 관련 오류 xml 오타나 구조를 제대로 작성했는지 확인 " + e);

        }


        return nodes;
      



    }

    public static void Load(string path, XmlLoad xml)
    {

        try{

            xml(path,Load(path));

        }
        catch (NullReferenceException e){

            Debug.Log("01:xml Load 오류(null point)");

        }
        catch (Exception e)
        {
            Debug.Log(e);

        }
  

    }


    public  delegate void XmlLoad(string path ,XmlNodeList nodes);


}

