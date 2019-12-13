using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMenuMnanger : MonoBehaviour
{
    [SerializeField]
    GameObject contentParent;
    [SerializeField]
    GameObject content;

    ContentManager contentManager;
    RectTransform parent;
    List<ModInfo> infose;
    protected void Awake()
    {
        
         parent = contentParent.GetComponent<RectTransform>();
         infose = ModCrwaler.instance.infoes;
        setModList();
    }


    public void setModList()
    {

        foreach(ModInfo info in infose)
        {
           GameObject content= Instantiate(this.content);
           contentManager = content.GetComponent<ContentManager>();
           contentManager.setText(info.name);
            contentManager.descibeText = info.describe;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.SetParent(contentParent.transform);
            contentRect.localScale = new Vector2(1f, 1f);
        }

    }

}
