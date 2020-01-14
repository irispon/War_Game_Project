using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharData : MonoBehaviour
{
    [SerializeField]
    Image charImage;
    [SerializeField]
    Text mainName, subName;


    UnitProperty unitProperty;

    protected void Awake()
    {
        unitProperty = new UnitProperty();

    }

    public void SetUnitproperty(UnitProperty unitProperty)
    {
        this.unitProperty = unitProperty;
        if(unitProperty.GetSprite() != null)
        {
            charImage.sprite = unitProperty.GetSprite();
        }

        mainName.text= unitProperty.unitName;
        subName.text = unitProperty.midleName;
    }
   
    public UnitProperty GetUnitProperty()
    {

        return unitProperty;
    }
    
    public void Click()
    {
        UnitCreatManager unitCreatManager = UnitCreatManager.instance;
 
        unitCreatManager.SetHolder(this);
    }

   

}
