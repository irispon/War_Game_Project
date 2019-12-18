using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainViewManager : SingletonObject<MainViewManager>
{
    [SerializeField]
    public GameObject ModMenu;


    protected override void Awake()
    {
        base.Awake();
        Screen.SetResolution(Screen.width, Screen.width *1920 /1080,true);
       


    }

    public void OpenModMenu()
    {
        GameObject menu = Instantiate(ModMenu);
        
        RectTransform rectTransform = menu.GetComponent<RectTransform>();

       
        rectTransform.SetParent(gameObject.transform);
        rectTransform.localScale = new Vector2(1f, 1f);
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
        Debug.Log(rectTransform.position.x);
    }

    
}
