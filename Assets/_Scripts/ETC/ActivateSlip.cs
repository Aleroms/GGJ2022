using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSlip : MonoBehaviour
{
    private RadioStationManager radioStationManager;
    private PointAndClick_Movement player;

    private void Start() 
    {
        radioStationManager = GameObject.Find("RadioStationManager").GetComponent<RadioStationManager>();
        player = GameObject.Find("PlayerJoe").GetComponent<PointAndClick_Movement>();
        player.enabled = true;
        player.gameObject.GetComponent<InteractionInstigator>().enabled = true;
        Slip();
    }

    public void Slip() 
    {
        radioStationManager.SlipClue();
    }
}
