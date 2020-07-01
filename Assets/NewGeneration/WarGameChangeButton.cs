using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarGameChangeButton : ChangeButton<Category>
{


    public override void Change()
    {

        Active(mode);


    }

    private void Active(Category manager) 
    {
      ObjectListManager objectListManager=  ObjectListManager.GetInstance();
        objectListManager.setMetaDatas( DataManager.GetInstance().FindInfos(manager));
    }

}
