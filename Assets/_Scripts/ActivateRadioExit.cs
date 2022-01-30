using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRadioExit : MonoBehaviour
{
    private RadioStationManager radioStationManager;
    void Start()
    {
        radioStationManager = GameObject.Find("RadioStationManager").GetComponent<RadioStationManager>();
        radioStationManager.ExitLevel();
    }


}
