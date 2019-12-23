using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMenuMnanger : SingletonObject<ModMenuMnanger>
{
    [SerializeField]
    GameObject unFillContent;
    [SerializeField]
    GameObject fillContent;
    [SerializeField]
    GameObject content;

    ContentManager contentManager;
    RectTransform parent;
    List<ModInfo> infose;
    List<string> modList;
    // List<GameObject> infoObjects;
    protected override void Awake()
    {
        base.Awake();
     //   infoObjects = new List<GameObject>();
         parent = unFillContent.GetComponent<RectTransform>();
        infose = new List<ModInfo>(ModCrwaler.instance.infoes);
        modList = new List<string>(ModCrwaler.instance.modList);
        setModList();
    }


    private void setModList()
    {
        int i = 0;
        foreach (ModInfo info in infose)
        {
            GameObject content = Instantiate(this.content);
            content.name = "컨텐츠" + i;
            i++;

            RectTransform contentRect = content.GetComponent<RectTransform>();

            contentManager = content.GetComponent<ContentManager>();
            contentManager.setInfo(info);


            if (!modList.Contains(info.name))
            {
                contentRect.SetParent(unFillContent.transform);
            }
            else
            {
                contentRect.SetParent(fillContent.transform);
            }
            contentRect.localScale = new Vector2(1f, 1f);

            //    infoObjects.Add(content);


        }

    }
    public void Activate()
    {
      foreach(Transform child in fillContent.transform)
        {

            ContentManager content = child.gameObject.GetComponent<ContentManager>();
            Debug.Log("모드 적용: "+content.info.name);

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
