using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    ListManager listManager;

    public void PutParts()
    {
        listManager.setInfos(Organs.GetInstance().GetOrgans());   
    }
}
