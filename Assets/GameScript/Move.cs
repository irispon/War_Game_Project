using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{

   static public void MoveToPosition(Transform transform,Vector3 position)
    {

        transform.position += position;

    }

    private void SmoothMove()
    {

    }
   
}
