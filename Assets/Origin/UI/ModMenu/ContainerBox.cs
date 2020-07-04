using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerBox : Content
{
    [SerializeField]
    GameObject contentField;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {

        //이미지 끌려가는 걸 표현(중요도 낮음)
    }

    public override void OnDrop(PointerEventData eventData)
    {
        GameObject containerContent = container.content;
        try
        {

            if (!containerContent.transform.parent.Equals(contentField.transform))
            {
                Debug.Log(" Parent 변경");
                containerContent.transform.SetParent(contentField.transform);
            }
        }
        catch (Exception e)
        {

        }

        container.content = null;

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
 
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        //포인터가 나가면 원래 색
    }
}
