using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    GameObject parentObject;

    public void DestoryClick()
    {
        Destroy(parentObject);
    }
}
