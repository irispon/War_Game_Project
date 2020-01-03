using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private FieldProperty fieldProperty;
    private SpriteRenderer sprite;
    private Transform fieldTransform;
    // Start is called before the first frame update
    private void Awake()
    {

        sprite = GetComponent<SpriteRenderer>();
        fieldTransform = GetComponent<Transform>();
       
    }

    public void setProperty(FieldProperty fieldProperty)
    {

        this.fieldProperty = fieldProperty;
        List<Sprite> sprites = this.fieldProperty.sprites;
        sprite.sortingOrder= (int)fieldProperty.type;
        sprite.sprite = sprites[Random.Range(0,sprites.Count)];
        // Debug.Log(""+sprite.sprite.rect);

       name = this.fieldProperty.uqName;
       sprite.sortingLayerName=this.fieldProperty.type.ToString();
       gameObject.layer = LayerMask.NameToLayer(this.fieldProperty.type.ToString());
        //this.fieldProperty.type.ToString() -> Layer이름

    }

    public void setTransform(Vector3 transform)
    {
        this.fieldTransform.position = transform;
    }

    public void setProperty()
    {
       

    }




}
