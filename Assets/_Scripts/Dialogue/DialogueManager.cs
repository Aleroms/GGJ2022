using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        } else 
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowDialogueBox(bool show) 
    {
        
    }
}
