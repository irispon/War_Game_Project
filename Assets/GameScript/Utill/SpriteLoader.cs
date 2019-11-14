﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SpriteLoader
{

    public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;
        Texture2D SpriteTexture = LoadTexture(FilePath);
      
        try
        {
            NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
            
        }
        catch (Exception e)
        {
            Debug.Log("텍스쳐 로딩 오류"+ FilePath +e);
            return null;
        }
      

        return NewSprite;
    }

    public static Texture2D LoadTexture(string FilePath)
    {
        Debug.Log("텍스쳐 경로: "+FilePath);
        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            Debug.Log("텍스쳐 존재");
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        Debug.Log("텍스쳐 존재x");
        return null;                     // Return null if load failed
    }
}


/*
 사멸 코드

using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SpriteLoader :MonoBehaviour
{

    private static SpriteLoader _instance;

    public static SpriteLoader instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.

            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SpriteLoader>();
            return _instance;
        }
    }


    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;
        Texture2D SpriteTexture = LoadTexture(FilePath);
      
        try
        {
            NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
            
        }
        catch (Exception e)
        {
            Debug.Log("텍스쳐 로딩 오류"+e);
            return null;
        }
      

        return NewSprite;
    }

    public Texture2D LoadTexture(string FilePath)
    {
        Debug.Log("텍스쳐 경로: "+FilePath);
        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            Debug.Log("텍스쳐 존재");
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        Debug.Log("텍스쳐 존재x");
        return null;                     // Return null if load failed
    }
}
     
     
     
     
     
     
     */
