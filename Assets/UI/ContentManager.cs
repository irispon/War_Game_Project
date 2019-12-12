using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject modImage;

    public void setText(string content)
    {
        Text contentText = text.GetComponent<Text>();
        contentText.text = content;

    }

    public void setModImage(Image image)
    {
        Image modImage = this.modImage.GetComponent<Image>();
        modImage.sprite = image.sprite;
    }

}
