using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The component will be on the spheres of the gates
public class GateEndLineController : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Transform[] points;
    private bool isMovingWire;
    private Vector3 mOffset;
    private float mZCoord;


    private void Awake() 
    {

    }

    private void Start() 
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = points.Length;
        this.points = points;
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < points.Length; i++) 
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    private void OnMouseDown() 
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

        print("Down");
    }

    private void OnMouseDrag() 
    {
        //lr.SetPosition(1, GetMouseWorldPos() + mOffset);
        points[1].transform.position = GetMouseWorldPos() + mOffset;
        print("Drag");
    }

    private Vector3 GetMouseWorldPos() 
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
