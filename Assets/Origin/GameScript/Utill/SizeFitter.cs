using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFitter 
{
 public static void Fitting(GameObject gameObject)
    {
        Transform transform = gameObject.transform;

        transform.localScale = new Vector3(1, 1, 1);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        Debug.Log(transform.localPosition);
    }
}
