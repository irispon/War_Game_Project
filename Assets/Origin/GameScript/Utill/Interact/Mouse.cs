using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse 
{
    public static Vector3 GetMousePosition()
    {

        Vector3 positon = Input.mousePosition;
        positon.z = 10f;
        return Camera.main.ScreenToWorldPoint(positon);
    }
}
