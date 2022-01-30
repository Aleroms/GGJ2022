using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateToCarShop : MonoBehaviour
{
    private RadioStationManager radioStationManager;
    // Start is called before the first frame update

    void Start()
    {
        radioStationManager.ExitLevel();
    }


}
