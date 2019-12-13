using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModDescribeManager : MonoBehaviour
{
    [SerializeField]
    GameObject decribeText;
    [SerializeField]
    GameObject image;

    public void SetDescribe(string text)
    {

        Text describe = decribeText.GetComponent<Text>();
        describe.text = text;
    }

    public void SetImage(Sprite image)
    {

        Image describe = this.image.GetComponent<Image>();
        describe.sprite = image;
    }
}
