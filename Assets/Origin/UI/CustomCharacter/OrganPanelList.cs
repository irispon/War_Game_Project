using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganPanelList : MonoBehaviour, IList<UnitProperty>
{

    [SerializeField]
    GameObject part, organ, content,parent;
    GameObject volatilityContent=null;
    UnitProperty property;
    DoubleKeyDictionary<Parts, string, Organ> organs;
    
    public void Bond(UnitProperty property)
    {
        this.property = property;
        organs = property.GetOrgans();
        ChangeList();
    }

    public void ChangeList()
    {
        if (volatilityContent != null)
        {
            Destroy(volatilityContent);
        }     
        volatilityContent = Instantiate(content);
        volatilityContent.transform.SetParent(parent.transform);
        volatilityContent.transform.localPosition = new Vector3(0, volatilityContent.transform.localPosition.y);

        this.GetComponent<ScrollRect>().content = volatilityContent.GetComponent<RectTransform>();
        SizeFitter.FittingSize(volatilityContent);
        volatilityContent.GetComponent<RectTransform>().sizeDelta = new Vector2(parent.GetComponent<RectTransform>().sizeDelta.x, 0);
        // PartControler pContoler = this.part.GetComponent<PartControler>();
        // OrganControler organControler = this.part.GetComponent<OrganControler>();

        foreach (Parts part in organs.Keys)
        {
           GameObject partPanel= Instantiate(this.part);
           PartControler pContoler = partPanel.GetComponent<PartControler>();
            pContoler.part.text = part.ToString();
    
            partPanel.transform.SetParent(volatilityContent.transform);
            SizeFitter.FittingSize(partPanel);
           
         

            //Debug.Log("장기 파츠: "+part);
            foreach (Organ name in organs[part].Values)
            {
                GameObject organPanel = Instantiate(this.organ);
                OrganControler oContoler = organPanel.GetComponent<OrganControler>();
                oContoler.name.text = name.name;
                oContoler.durable.text = name.durable.ToString();
                oContoler.efficiency.text = name.efficiency.ToString();
                
                organPanel.transform.SetParent(volatilityContent.transform);
                SizeFitter.FittingSize(organPanel);
                // Debug.Log("장기 명: " + name.name);
                // Debug.Log("내구도: " + name.durable);
                // Debug.Log("효율: " + name.efficiency);
            }

        }
    }

    public void Remove()
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
