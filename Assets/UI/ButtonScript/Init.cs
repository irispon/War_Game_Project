using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
   public void init()

   {
        ObjectManager.GetInstance().DestoryAll();
       
        
   }
}
