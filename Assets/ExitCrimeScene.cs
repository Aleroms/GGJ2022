using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCrimeScene : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			GameObject.Find("CrimeSceneManager").GetComponent<CrimeSceneManager>().ExitCrimeScene();

		}
	}
}
