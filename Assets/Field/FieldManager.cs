using UnityEngine;
using System;
using System.Collections.Generic; 		
using Random = UnityEngine.Random; 		


public class FieldManager : MonoBehaviour
{


    public int columns = 8;                                         //게임 보드 columns
    public int rows = 8;                                            //게임 보드 rows
   // public Count wallCount = new Count(5, 9);                       //벽 숫자
    public GameObject[] floorTiles;                                 //바닥
    public GameObject[] wallTiles;                                  //벽
    public GameObject[] outerWallTiles;                             //외벽
    public GameObject[] Unit;							        	//Unit


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
