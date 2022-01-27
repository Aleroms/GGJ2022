using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelLoader : MonoBehaviour
{
    public Image MapBackground;
    public Sprite[] currentLevel;
    public Button[] buttons;

    void Start()
    {
        int lvl = GameManager.Instance.GetCurrentLevel();
        
        SelectBackground(lvl);
        InitializeButtons(lvl);

    }
    private void SelectBackground(int lvl)
	{
        try
        { MapBackground.sprite = currentLevel[lvl - 1]; }
        catch
        { Debug.LogError("Index out of bounds"); }
    }
    private void InitializeButtons(int lvl)
	{
        try
        { buttons[lvl - 1].interactable = true; }
        catch
        { Debug.LogError("Index out of bounds"); }
    }
    public void ButtonPress(int lvl)
	{
        Debug.Log("Button Pressed");
        GameManager.Instance.LoadLevel(lvl);
        Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
