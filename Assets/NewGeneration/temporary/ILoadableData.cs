using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadableData
{
 
     DataKinds GetDataKind();
     string Identify();
  
}
