using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Deselect()//선택 해제 되었을 때를 기술
    {
        base.Deselect();
       
    }

    public void Select()//선택 되었을 때를 기술
    {
        base.Select();
       
    }

    public void Move(Vector3 position)//움직임을 기술
    {

    }


}
