using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameFieldManager : MonoBehaviour
{


    public int columns = 15;                                         //게임 보드 columns
    public int rows = 8;                                            //게임 보드 rows
                                                                    // public Count wallCount = new Count(5, 9);                       //벽 숫자
    public GameObject floor;
    public GameObject[] wallTiles;                                  //벽
    public GameObject[] outerWallTiles;                             //외벽
    public GameObject[] Unit;							        	//Unit



    private static GameFieldManager instance;
    private TileManager floorTiles;                                 //바닥

    private WDictionary<Vector2, GameObject> board;//보드의 좌표 + 오브젝트 위치
    private Transform boardHolder;//보드판


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

        board = new WDictionary<Vector2, GameObject>();
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


    public static GameFieldManager GetFieldManager()
    {
        if (GameFieldManager.instance == null)
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
                Vector2 vector = new Vector3(x, y, 0f);
                if (x == -1 || x == columns || y == -1 || y == rows)
                {


                    instance = floorTiles.MakeFloor("Core_Wall", vector);

                }
                else
                {
                    instance = floorTiles.MakeFloor("Core_Dirt", vector);


                }


                board.Add(vector, instance);
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


        positon = Corrector(positon);

        gameObject.transform.position = positon;
        gameObject.transform.SetParent(boardHolder);

    }


    public void OverrideSettingBoard(GameObject gameObject)
    {
        Vector2 vector = gameObject.transform.position;
        vector = Corrector(vector);
        Debug.Log("vector?" + vector);
        if (board.ContainsKey(vector))
        {
            Debug.Log("겹치는 것 삭제");
            Destroy(board[vector]);
            board.Remove(vector);


        }
        board.Add(vector, gameObject);
        SetBoard(gameObject);
    }


    private Vector3 Corrector(Vector3 vector)
    {
        if (vector.x >= 0)
        {
            vector.x = (int)vector.x;
        }
        else
        {
            vector.x = Math.Abs(vector.x);
            vector.x = (int)Math.Ceiling(vector.x);
            vector.x = -vector.x;


        }

        if (vector.y >= 0)
        {
            vector.y = (int)vector.y;
        }
        else
        {
            vector.y = Math.Abs(vector.y);
            vector.y = (int)(Math.Ceiling(vector.y));
            vector.y = -vector.y;
        }


        return vector;
    }
}
