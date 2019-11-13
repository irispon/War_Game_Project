using System;
using UnityEngine;

public class FieldProperty
{
    public double disturbanceDegree { get; set; } = 0;
    public int type { get; set; } = 1;
    public double rare { get; set; } = 0.1;
    public Sprite sprite { get; set; } = null;
    public string name { get; set; } = "blank";
    public string uqName { get; set; } = "";

    public static int Parse(string type)
    {
        Layer layer = (Layer)Enum.Parse(typeof(Layer), type);
        Debug.Log("" + layer.ToString());
        try
        {

            return int.Parse(layer.ToString());
        }
        catch(Exception e)
        {
            Debug.Log("Type 변경 실패");

            return 0;
            
        }


        

 
    }

    

}

