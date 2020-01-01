using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MetaData :MonoBehaviour ,IDrag,IDrop
{
    [SerializeField]
    GameObject Text, Image;


    private Image image;
    private TextMeshProUGUI text;

    private ObjectAdapter adapter;
    public IObjectInfo info;
    private GameObject content;

    public void Awake()
    {
        if(Image != null)
        {
            image = Image.GetComponent<Image>();
        }
        if(Text != null)
        {
            text = Text.GetComponent<TextMeshProUGUI>();
        }

         adapter = new ObjectAdapter();
         info = null;
        content = Container.instance.content;
    }


    private void SetImage(Sprite image)
    {
        this.image.sprite = image;

    }
    private void SetText(string text)
    {
        this.text.text = text;

    }

    public void SetObjectInfo(IObjectInfo info)
    {
        this.info = info;
        adapter.SetObject(info);
        SetImage(info.GetSprite());
        SetText(info.GetName());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        content = new GameObject();
        content.AddComponent<SpriteRenderer>();
        content.GetComponent<SpriteRenderer>().sprite = info.GetSprite();
        content.transform.position = Mouse.GetMousePosition();
        Debug.Log("draging 됨");
    }

    public void OnDrag(PointerEventData eventData)
    {
       content.transform.position = Mouse.GetMousePosition(); 
        Debug.Log("draging 되는중+" + Mouse.GetMousePosition());
    }

    public void OnDrop(PointerEventData eventData)
    {


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(content);
        content = null;
        GameObject gameObject = adapter.Creat();
        
       
        gameObject.transform.position = Mouse.GetMousePosition();
        Debug.Log("draging 끝남");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("포인터 입장");
        image.color = new Color32(255, 255, 255, 100);
        
     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("포인터 퇴장");
        image.color = new Color32(255, 255, 255, 255);
    }


}
