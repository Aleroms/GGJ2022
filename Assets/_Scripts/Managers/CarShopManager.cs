using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShopManager : MonoBehaviour
{
    public GameObject MainLights;
	public GameObject mapLoader;

	private void Start()
	{
		MainLights.SetActive(false);
		mapLoader.SetActive(false);
	}
	
	public void MainLightsON()
	{
		MainLights.SetActive(true);
	}
	public void ExitCarShop()
	{
		

		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;
		GameManager.Instance.CarShopComplete();

		AudioManager.instance.Play("map-open");
		mapLoader.SetActive(true);
	}
}
