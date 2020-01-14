using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitCreatManager : SingletonObject<UnitCreatManager>
{

    [SerializeField]
    TMP_InputField firstName, midleName;
    [SerializeField]
    Image Profile;
    [SerializeField]
    GameObject Organs, Traits;

    CharData holder;
    IList<UnitProperty> OrList, TrList;

    protected override void Awake()
    {
        base.Awake();
        CustomUnitManager.instance.Join(this);
        OrList = Organs.GetComponent<IList<UnitProperty>>();
        //TrList = Traits.GetComponent<IList>();

    }

    public void SetName(string first=null,string midle=null)
    {
      
        if (first != null)
        {
            firstName.text = first;

        }
        if (midle != null)
        {

            midleName.text = midle;
        }

    }

    public void SetImage(Sprite image = null)
    {
        if (image != null)
        {
            Debug.Log("이미지 복사 성공");
            Profile.sprite = image;
        }

    }

    public void SetHolder(CharData charData)
    {
        this.holder = charData;
        UnitProperty unit = holder.GetUnitProperty();
        SetName(unit.unitName, unit.midleName);
        SetImage(unit.sprite);
        OrList.Bond(holder.GetUnitProperty());
    }


    public void Click()
    {
        UnitProperty unitProperty = holder.GetUnitProperty();

        unitProperty.unitName = firstName.text;
        unitProperty.midleName = midleName.text;
        unitProperty.sprite = Profile.sprite;
        holder.SetUnitproperty(unitProperty);



    }
}
