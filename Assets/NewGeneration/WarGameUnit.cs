using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarGameUnit : MonoBehaviour, IWarGameUnit
{


    private WarGameUnitData unitData;
    private SpriteRenderer charChip;
    private WonBasicAI ai;
    private AIUnitAdater aiUnitAdater;

    //유닛 사거리에 대한 아이디어(콜리전을 이용하여 안쪽에 들어오면 해당 공격 루틴을 호출)


    public void Join(IObjectInfo unitData)
    {
        SetUnitData(unitData);
        UnitMaster.instance.JoinUnit(this.unitData, this);

    }

    public void SetUnitData(IObjectInfo unitData)
    {
        
        this.unitData = (WarGameUnitData)unitData;



    }

    

    /*인터페이스 부분*/

    public void Draw()
    {
      //  charChip.size = this.GetComponent<BoxCollider2D>().size;
        charChip.sprite= unitData.warGameUnitGhraphic.Idle.sprite;

    }

    public void GetDamage(int damage)
    {
     // => UnitMaster에게 전달
    }



    public void Move()
    {
       
    }
    /*인터페이스 부분*/

    // Start is called before the first frame update

     void Start()
    {

        charChip = this.GetComponent<SpriteRenderer>();
        //  charChip.size = this.GetComponent<BoxCollider2D>().size;
        this.GetComponent<BoxCollider2D>().edgeRadius = 1;
        charChip.sortingLayerName = Layer.Unit.ToString();
        ai = WonBasicAI.GetAI<WonBasicAI>(this.gameObject);
        Forward();
        Debug.Log("초기화 완료");
        AIUnitAdater.GetAIUnitAdater(gameObject).warGameUnit = this;
        aiUnitAdater = AIUnitAdater.GetAIUnitAdater(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Forward()
    {
        unitData.warGameUnitGhraphic.Idle = unitData.warGameUnitGhraphic.Forward;
        Draw();
    }

    public void Back()
    {
        unitData.warGameUnitGhraphic.Idle = unitData.warGameUnitGhraphic.Back;
        Draw();
    }

    public void Right()
    {
        unitData.warGameUnitGhraphic.Idle = unitData.warGameUnitGhraphic.Right;
        Draw();
    }

    public void Left()
    {
        unitData.warGameUnitGhraphic.Idle = unitData.warGameUnitGhraphic.Left;
        Draw();
    }

    public void SetChip(WarGameUnitGhraphic graphic)
    {
        unitData.warGameUnitGhraphic = graphic;
        unitData.warGameUnitGhraphic.Idle = unitData.warGameUnitGhraphic.Forward;
        Draw();
    }

    public void Destroy()
    {
        UnitMaster.instance.DetatchUnit(unitData);
        Destroy(this);
    }

    public IObjectInfo GetData()
    {
        return unitData;
    }

    void OnMouseDown()
    {
        Debug.Log("test");
       // Debug.Log(GetComponent<BoxCollider2D>().bounds);
        //Debug.Log(charChip.sprite.pivot + "with" + charChip.sprite.rect.width + "height" + charChip.sprite.rect.height);
       // ai.Change<CommanderAI>(ai, gameObject);
        if (aiUnitAdater.wonBasicAI != null)
        {
            aiUnitAdater.wonBasicAI.Search();
        }
    }

    public WarGameUnitData GetUnitData(WarGameUnitData unitData)
    {
        return unitData;
    }
}
