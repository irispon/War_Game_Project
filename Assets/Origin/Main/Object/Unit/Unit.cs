using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Move;

public class Unit : MonoBehaviour, ISelectable, IMoveable
{

   protected UnitManager unitMnager = UnitManager.getInstance();
   protected SpriteRenderer spriteRenderer;
   protected UnitProperty unitProperty;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      //  spriteRenderer.sprite= SpriteLoader.LoadNewSprite("/Splites/sprite0.png");

    }
    public void Deselect()
    {
        unitMnager.Detach(this);
        /*select 되었을 때 초록색 원 해제*/
    }

    public void Select()
    {
        
        unitMnager.Join(this);
        /*select 되었을 때 초록색 원 추가*/
    }


    public void Move(Vector3 positon)
    {

        MoveToPosition(transform, positon);
       
    }

    protected void Render()
    {
        


    }

    public void setUnitProperty(string raceUqName)
    {
        unitProperty = new UnitProperty(raceUqName);

    }
    public void setUnitProperty(Race race)
    {
        unitProperty = new UnitProperty(race);

    }

    public void setUnitProperty(UnitProperty unitProperty)
    {
        this.unitProperty = unitProperty;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        Generate(Races.GetInstance().getRace());

    }

    public void Generate(string raceName)
    {
        Generate(Races.GetInstance().getRace(raceName));
    }

    protected void Generate(Race race)
    {
        setUnitProperty(race);
       

    }



}
