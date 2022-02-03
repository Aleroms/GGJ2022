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
       switch(lvl)
		{
            case 2:
                AudioManager.instance.Stop("bar-postdeath-loop");
                AudioManager.instance.Play("radio-station-loop");
                break;
            case 3:
                AudioManager.instance.Stop("radio-station-loop");
                AudioManager.instance.Play("carshop-loop");
                AudioManager.instance.Play("map-close");
                break;
            case 4:
                AudioManager.instance.Stop("carshop-loop");
                AudioManager.instance.Play("pier-loop");
                AudioManager.instance.Play("map-close");

                break;
		}

        Debug.Log("Button Pressed");
        GameManager.Instance.LoadLevel(lvl);
        Destroy(gameObject);
	}
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
