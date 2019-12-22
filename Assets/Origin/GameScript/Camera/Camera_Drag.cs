using UnityEngine;
using System.Collections;
public class Camera_Drag : MonoBehaviour
{
    public float dragSpeed =-20f;
    private Vector3 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

        Vector3 move = new Vector3(pos.x * dragSpeed*Time.deltaTime, pos.y * dragSpeed * Time.deltaTime, 0 );

        transform.Translate(move, Space.World);
        
    }


}
