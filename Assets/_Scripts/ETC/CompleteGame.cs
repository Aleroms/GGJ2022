using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGame : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CompletePier();
    }

    public void CompletePier() 
    {
        AudioManager.instance.Stop("pier-loop");
        AudioManager.instance.Play("credits");
        gameManager.PeirComplete();
    }
}
