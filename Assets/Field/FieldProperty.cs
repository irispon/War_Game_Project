using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldProperty
{
    public double disturbanceDegree { get; set; } = 0;
    public Layer type { get; set; } = Layer.Floor;
    public double rare { get; set; } = 0.1;
    public Sprite sprite { get; set; } = null;


    public List<Sprite> sprites;
    public string name { get; set; } = "blank";
    public string uqName { get; set; } = "";

    public FieldProperty()
    {
        sprites = new List<Sprite>();

    }

    public void addSprite(String path)
    {
        sprites.Add(SpriteLoader.LoadNewSprite(path));

    }


    public static Layer Parse(string type)
    {
        Layer layer = Layer.Floor;

        try
        {
            layer = (Layer)Enum.Parse(typeof(Layer), type);
            Debug.Log("Layer:" + layer.ToString());

            return layer;
        }
        catch(Exception e)
        {
            Debug.Log("Type 변경 실패 디폴트 설정으로 변경됩니다.");

          
            
        }

        return layer;

        

 
    }



    

}

