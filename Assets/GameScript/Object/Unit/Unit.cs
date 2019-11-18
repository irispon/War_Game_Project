using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Move;

public class Unit : MonoBehaviour, ISelectable, IMoveable
{

   private UnitManager unitMnager = UnitManager.getInstance();
   private SpriteRenderer SpriteRenderer;
   private UnitProperty unitProperty;


    public void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void Deselect()
    {
        unitMnager.Detach(this);
        throw new System.NotImplementedException();
        /*select 되었을 때 초록색 원 해제*/
    }

    public void Select()
    {
        
        unitMnager.Join(this);
        throw new System.NotImplementedException();
        /*select 되었을 때 초록색 원 추가*/
    }


    public void Move(Vector3 positon)
    {

        MoveToPosition(transform, positon);
       
    }

    private void Render()
    {
        


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
