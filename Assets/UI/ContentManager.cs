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
    private Rect describeRect = new Rect(531.3f, -346.56f, 1062.6f, 693.12f);

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
        Vector2 anchor = new Vector2( cloneTransform.anchoredPosition.x, cloneTransform.anchoredPosition.y);
        cloneTransform.SetParent(MainViewManager.instance.transform);
        cloneTransform.localScale = new Vector2(1f, 1f);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(cloneDescribePanel);
    }
}
