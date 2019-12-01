using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Move;

public class Unit : MonoBehaviour, ISelectable, IMoveable
{

   private UnitManager unitMnager = UnitManager.getInstance();
   private SpriteRenderer spriteRenderer;
   private UnitProperty unitProperty;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      //  spriteRenderer.sprite= SpriteLoader.LoadNewSprite("/Splites/sprite0.png");

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

    private void Generate(Race race)
    {
        setUnitProperty(race);
       

    }



}
