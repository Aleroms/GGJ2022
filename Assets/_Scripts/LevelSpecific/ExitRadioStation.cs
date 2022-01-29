using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRadioStation : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameObject.Find("RadioStationManager").GetComponent<RadioStationManager>().ExitRadioStation();

		}
	}
}
