using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWorkBench : MonoBehaviour
{
    public GameObject InteractiveWorkBench;

    public void MakeAvalible() 
    {
        Instantiate(InteractiveWorkBench, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
