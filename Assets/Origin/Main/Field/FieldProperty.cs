using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldProperty:IObjectInfo
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

    public string GetName()
    {
        return name;
    }

    public string GetUqName()
    {
        return uqName;
    }

    public Sprite GetSprite()
    {
        return sprites[0];
    }
}

