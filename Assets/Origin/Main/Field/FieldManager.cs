using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FieldManager : MonoBehaviour
{


    public int columns = 15;                                         //게임 보드 columns
    public int rows = 8;                                            //게임 보드 rows
   // public Count wallCount = new Count(5, 9);                       //벽 숫자
    public GameObject floor;
    public GameObject[] wallTiles;                                  //벽
    public GameObject[] outerWallTiles;                             //외벽
    public GameObject[] Unit;							        	//Unit
    private Transform boardHolder;
    private static FieldManager instance;
    private TileManager floorTiles;                                 //바닥



    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);


        }
      

       // DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        BoardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        Debug.Log("초기화");
        boardHolder = null;
        floorTiles = TileManager.instance;

    }

    
    public static FieldManager GetFieldManager()
    {
        if (FieldManager.instance == null)
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<FieldManager>();
        }
        return instance;
    }

    private void FloorCreat(int colums, int rows)
    {
       


    }

   private void BoardSetup()
    {

        boardHolder = new GameObject("Board").transform;
        
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject instance;
   
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                   
                    instance = floorTiles.MakeFloor("Core_Wall", new Vector3(x, y, 0f));

                } else
                {
                    instance = floorTiles.MakeFloor("Core_Dirt",new Vector3(x, y, 0f));
                    

                }


                instance.transform.SetParent(boardHolder);
               
            }
        }
    }


    public Transform GetBoard()
    {
        if (boardHolder == null)
        {
            boardHolder = new GameObject("Board").transform;
        }
        return boardHolder;
    }

    public void SetBoard(GameObject gameObject)
    {
        Vector3 positon = gameObject.transform.position;

 
        positon.x = (int)positon.x;
        positon.y = (int)positon.y;

        gameObject.transform.position = positon;
        gameObject.transform.SetParent(boardHolder);

    }

}
