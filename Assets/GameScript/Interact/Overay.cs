using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Overay : MonoBehaviour
{

    private Vector3 originScale;
    private Vector3 overScale;
    private bool select = false;
    private UnitManager unitManager;
    


    // Start is called before the first frame update
    void Start()
    {
        originScale = transform.localScale;
        overScale = new Vector3(0.3f,0.3f,0f)+transform.localScale;
        unitManager = UnitManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {

   
    }

    private void OnMouseOver()
    {

        transform.localScale = overScale;

    }

    private void OnMouseExit()
    {
        transform.localScale = originScale;

    }

    private void OnMouseDown()
    {
        


    }

    
}
