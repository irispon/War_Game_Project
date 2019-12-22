using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMenuMnanger : SingletonObject<ModMenuMnanger>
{
    [SerializeField]
    GameObject contentParent;
    [SerializeField]
    GameObject content;

    ContentManager contentManager;
    RectTransform parent;
    List<ModInfo> infose;
    List<GameObject> infoObjects;
    protected override void Awake()
    {
        base.Awake();
        infoObjects = new List<GameObject>();
         parent = contentParent.GetComponent<RectTransform>();
        infose = new List<ModInfo>(ModCrwaler.instance.infoes);
        setModList();
    }


    private void setModList()
    {
        int i = 0;
        foreach (ModInfo info in infose)
        {

           GameObject content= Instantiate(this.content);
            content.name = "컨텐츠" + i;
            i++;

            RectTransform contentRect = content.GetComponent<RectTransform>();

            contentManager = content.GetComponent<ContentManager>();
            contentManager.setText(info.name);
            contentManager.descibeText = info.describe;
            contentRect.SetParent(contentParent.transform);

            contentRect.localScale = new Vector2(1f, 1f);

            infoObjects.Add(content);


        }

    }

    /*
    public void ObjectListClear()
    {
        foreach(GameObject infoObj in infoObjects)
        {
            Destroy(infoObj);
        }

    }
    public void Remove(GameObject obj)
    {
       if(infoObjects.Contains(obj))
        {
            infoObjects.Remove(obj);
            Destroy(obj);
        }
    }
*/

}
