using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsDragLayer;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        Draggable draggableMouseIsOver = IsMouseOverDraggable();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print(worldPosition);

        if(draggableMouseIsOver != null) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                draggableMouseIsOver.GetComponentInChildren<Renderer>().material.color = new Color(0, 255, 0);
                
                draggableMouseIsOver.transform.position = new Vector3(worldPosition.x, 0, worldPosition.y);
            }
        }
    }

    // Return the grid cell if mouse is over a grid cell and returns null if it is not
    private Draggable IsMouseOverDraggable() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, whatIsDragLayer)) 
        {
            
            return hitInfo.transform.GetComponent<Draggable>();
        }

        return null;
    }
}
