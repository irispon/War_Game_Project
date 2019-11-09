using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FieldManager : MonoBehaviour
{


    public int columns = 15;                                         //게임 보드 columns
    public int rows = 8;                                            //게임 보드 rows
   // public Count wallCount = new Count(5, 9);                       //벽 숫자
    public GameObject[] floorTiles;                                 //바닥
    public GameObject[] wallTiles;                                  //벽
    public GameObject[] outerWallTiles;                             //외벽
    public GameObject[] Unit;							        	//Unit
    public Transform boardHolder;
    


    // Start is called before the first frame update
    void Start()
    {
        BoardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FloorCreat(int colums, int rows)
    {
       


    }

    void BoardSetup()
    {
 
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];

                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }




}
