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
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			ExitCarShop();
		}
	}
	public void MainLightsON()
	{
		MainLights.SetActive(true);
	}
	public void ExitCarShop()
	{
		

		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;
		GameManager.Instance.CarShopComplete();

		mapLoader.SetActive(true);
	}
}
