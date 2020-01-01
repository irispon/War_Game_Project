using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    [SerializeField]
    Category mode;

    public void Change()
    {
        ObjectListManager.instance.Change(mode);
    }
}
