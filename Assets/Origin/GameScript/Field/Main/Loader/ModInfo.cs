using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModInfo
{
    public const string NAME = "Name";
    public const string SUBDESCRIBE = "SubDescribe";
    public const string DESCRIBE = "Describe";
    public const string NECESSARYMODE = "NecessaryMode";


    public string name{ get; set; }
    public string subdescribe { get; set; }
    public string describe { get; set; }
    public string[] necessaryMode { get; set; }
    public string directory { get; set; }


}
