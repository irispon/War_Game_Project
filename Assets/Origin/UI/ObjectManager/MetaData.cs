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

  
    public IObjectInfo info;
    private GameObject content;

    private Vector2 correctVector;

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
       
        SetImage(info.GetSprite());
        SetText(info.GetName());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SpriteRenderer renderer;

        content = new GameObject();
        content.AddComponent<SpriteRenderer>();

        renderer = content.GetComponent<SpriteRenderer>();
        renderer.sprite = info.GetSprite();
        renderer.sortingLayerName = Layer.UI.ToString();

        correctVector = renderer.size/2;
        content.transform.position = Mouse.CorrectMousePosition(correctVector);


        //Debug.Log("draging 됨"+ content.transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
       content.transform.position = Mouse.CorrectMousePosition(correctVector);
   
    }

    public void OnDrop(PointerEventData eventData)
    {


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(content);
        content = null;
        GameObject gameObject = info.GetParent().MakeObject(info);
        Debug.Log("Mouse.GetMousePosition()" + Mouse.GetMousePosition());
        gameObject.transform.position = Mouse.GetMousePosition();
        if (info.GetCategory() == Category.Tile)
        {
            FieldManager.GetFieldManager().OverrideSettingBoard(gameObject);
        }
        else
        {
            FieldManager.GetFieldManager().SetBoard(gameObject);
        }


   
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 100);
        
     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 255);
    }


}
