using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour, OverayMenu
{
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject modImage;
    [SerializeField]
    GameObject describePanel;
    private GameObject cloneDescribePanel;
    private const float padding = 80f; 


    public string descibeText { get; set; }
    public Sprite sprite { get; set; }

    public void setText(string content)
    {
        Text contentText = text.GetComponent<Text>();
        contentText.text = content;

    }

    public void setModImage(Sprite sprite)
    {
        Image modImage = this.modImage.GetComponent<Image>();
        modImage.sprite = sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        cloneDescribePanel = Instantiate(describePanel);
        ModDescribeManager manager = cloneDescribePanel.GetComponent<ModDescribeManager>();
        manager.SetDescribe(descibeText);
        manager.SetImage(sprite);
        RectTransform cloneTransform = cloneDescribePanel.GetComponent<RectTransform>();
        RectTransform modMenuTransform = ModMenuMnanger.instance.GetComponent<RectTransform>();
        cloneTransform.SetParent(MainViewManager.instance.transform);
        cloneTransform.localScale = new Vector2(1f, 1f);
        cloneTransform.anchoredPosition = modMenuTransform.anchoredPosition + new Vector2(modMenuTransform.rect.width+ padding, 0f);
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(cloneDescribePanel);
    }
}
