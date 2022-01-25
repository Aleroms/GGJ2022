using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    void OnMouseDown() 
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos = mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag() 
    {
        // pixel coordinates (x, y)
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos() 
    {
        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object
        mousePoint.z =  mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
