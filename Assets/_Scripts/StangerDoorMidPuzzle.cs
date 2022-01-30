using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StangerDoorMidPuzzle : MonoBehaviour
{
    public GameObject FinalStrangerDoor;


    public void SpawnFinalDoor() 
    {
        Instantiate(FinalStrangerDoor, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
