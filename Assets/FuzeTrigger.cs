using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzeTrigger : MonoBehaviour
{
	private CarShopManager carManager;

	private void Start()
	{
		carManager = GameObject.Find("CarShopManager").GetComponent<CarShopManager>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			carManager.MainLightsON();
		}
	}
}
