using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : SingletonObject<UnitList>
{

    List<GameObject> infos;
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        infos = new List<GameObject>();
    }
   public void Add(GameObject charData)
    {
        charData.transform.SetParent(transform);
        infos.Add(charData);
        SizeFitter.FittingSize(charData);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
