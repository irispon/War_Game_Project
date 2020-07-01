using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldChangeButton : ChangeButton<Category>
{


    public override void Change()
    {
        OldObjectListManager.instance.Change(mode);
    }
}
