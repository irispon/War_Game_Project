using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class CharacterLoadManager :LoadManager<CharacterLoadManager,WarGameUnitData>
{



    public CharacterLoadManager():base()
    {
        
    }


    public override void Load()
    {
        Debug.Log("로딩 테스트 CharacterL" +
            "oadManager");

        Temporary temporary = new Temporary();
        foreach (WarGameUnitData data in temporary.CharData())
        {

            dataManager.Add(data.uniqName,data);
            Debug.Log("유니크 네임 :"+data.uniqName +"  유닛 네임 : "+ data.unitName);
        }
      
    }

    public void Load(string path, XmlNodeList nodeList)
    {


    }

}
