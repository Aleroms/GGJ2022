using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayElectronicsTrigger : MonoBehaviour
{
	private RadioStationManager dj_mngr;
	private void Start()
	{
		dj_mngr = GameObject.Find("RadioStationManager").GetComponent<RadioStationManager>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			dj_mngr.StartElectronicsPuzzle();
		}
	}
}
