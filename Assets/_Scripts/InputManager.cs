using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsGridLayer;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        print(cellMouseIsOver);

        if(cellMouseIsOver != null) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                // print(cellMouseIsOver.GetComponentInChildren<Renderer>().material.color);
                cellMouseIsOver.GetComponentInChildren<Renderer>().material.color = new Color(0, 255, 0);
            }
        }
    }

    // Return the grid cell if mouse is over a grid cell and returns null if it is not
    private GridCell IsMouseOverAGridSpace() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, whatIsGridLayer)) 
        {
            return hitInfo.transform.GetComponent<GridCell>();
        }

        return null;
    }
}
