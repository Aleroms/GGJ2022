using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private int height = 10;
    private int width = 10;
    private float gridSpaceSize = 1.2f;

    [SerializeField] private GameObject gridCellPrefab;
    private GameObject[,] gameGrid;

    void Start() 
    {
        CreateGrid();
    }

    // Crates the grid when the game starts
    private void CreateGrid() 
    {
        gameGrid = new GameObject[height, width];

        if (gridCellPrefab == null) 
        {
            Debug.LogError("ERROR: Grid Cell Prefab on the Game grid is not assigned");
            return;
        }

        // Make the grid
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                gameGrid[x,y] = Instantiate(gridCellPrefab, new Vector3(x * gridSpaceSize, 0, y * gridSpaceSize), Quaternion.identity);
                gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                gameGrid[x, y].transform.parent = transform;
                gameGrid[x, y].gameObject.name = "Grid Space ( X: " + x.ToString() + ", Y: " + y.ToString() + ")";
            }
        }
    }

    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition) 
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x, y);
    }

    public Vector3 GetWorldPosFromGridPs(Vector2Int gridPos) 
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;

        return new Vector3(x, 0, y);
    }
}