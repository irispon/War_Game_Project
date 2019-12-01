using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ThingLoader :Loader
{
    private const string catagory = "catagory";

    /* organ xml form*/



   

    
    public override void Load(string path, XmlNodeList nodeList)
    {


        string tag = nodeList[0].InnerText;
        Debug.Log("카테고리 확인" + tag);

        switch (tag)
        {
            case Organ.CATAGORY:
                OrganLoad(path, nodeList);
                break;

            case Race.CATAGORY:
                RaceLoad(path,nodeList);
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
            Parts part=organ.part;
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
            organ.Durable = durable;
     
            organ.part = part;
            organ.efficiency = efficiency;

            Debug.Log("xml 노드 확인: " + ThingDefName);

            organs.addOrgan(organ);
        }

    }

    private void RaceLoad(string path, XmlNodeList nodeList)
    {


         Races races = Races.GetInstance();

       


        for (int i = 1; i < nodeList.Count; i++)
        {
            Race race = new Race();
            XmlNode node = nodeList[i];
            race.uqName = node.Attributes[PARENTNAME].Value;
            Debug.Log(race.uqName);
            race.name = node.SelectSingleNode(Race.DEFNAME).InnerText;

            // race.parts = new WList<string>(node.SelectSingleNode(Race.PART).InnerText.Split(','));
            
            foreach (XmlNode part in node.SelectNodes(Race.PART))
            {
                string organDef = part.SelectSingleNode(Race.ORGANDEF).InnerText;
                string organName = part.SelectSingleNode(Race.ORGANNAME).InnerText;
                Debug.Log("유닛 장기 추가:" + organName);
                Organ organ = Organs.GetInstance().getOrgan(organDef);
                try
                {
                    organ.efficiency *= float.Parse(part.SelectSingleNode(Race.EFFICIENCY).InnerText);
                }
                catch (Exception e)
                {
                    Debug.Log("효율 Parsing 에러" + e);
                }

                organ.efficiency *= float.Parse(part.SelectSingleNode(Race.EFFICIENCY).InnerText);
              
                race.parts.Add(organName, organ);
                
            }

            try
            {

                //race.efficiency = float.Parse(node.SelectSingleNode(Race.EFFICIENCY).InnerText);
   
            }
            catch (Exception e)
            {
                Debug.Log("RaceLoad Parsing 에러"+e );

            }

            races.addRace(race);



        }


        /*
        // clone 테스트
        Race test1 = races.getRace("Human");
        Race test2 = races.getRace("Human");
        ItemInfo info = new ItemInfo();
        ItemInfo info1 = info.Copy();

        info1.setDefName("aaa");
        Debug.Log("test1 part:" + info1.getDefName());
        Debug.Log("test2 part:" + info.getDefName());

    */


    }



}
