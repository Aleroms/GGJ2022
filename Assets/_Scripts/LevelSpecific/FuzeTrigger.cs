using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzeTrigger : MonoBehaviour
{
	private CarShopManager carManager;
	private ActivateWorkBench activateWorkBench;

	public GameObject cookies;

	private void Start()
	{
		carManager = GameObject.Find("CarShopManager").GetComponent<CarShopManager>();
		activateWorkBench = GameObject.Find("StartingWorkBenchNToolBox").GetComponent<ActivateWorkBench>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			AudioManager.instance.Play("lights");
			cookies.SetActive(false);
			carManager.MainLightsON();
			activateWorkBench.MakeAvalible();
		}
	}
}
