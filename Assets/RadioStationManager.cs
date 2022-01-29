using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStationManager : MonoBehaviour
{
	public GameObject radioBoothDoor;
	public GameObject electronicsPuzzleUI;
	public GameObject nextLevelLight;
	public GameObject mapLoader;
	public bool puzzleComplete;

	private void Start()
	{
		puzzleComplete = false;
		electronicsPuzzleUI.SetActive(false);
		nextLevelLight.SetActive(false);
		
	}

	public void ExitRadioStation()
	{
		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;

		mapLoader.SetActive(true);
	}

	public void StartRadioStation()
	{
		radioBoothDoor.SetActive(false);
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			StartRadioStation();
		}
	}
	public void StartElectronicsPuzzle()
	{
		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;
		electronicsPuzzleUI.SetActive(true);
	}
	public void ElectronicsPuzzleComplete()
	{
		puzzleComplete = true;

		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = true;
		electronicsPuzzleUI.SetActive(false);

		GameManager.Instance.ElectronicsPuzzleComplete();

		
	}
	public bool isPuzzleComplete()
	{
		return puzzleComplete;
	}
	public void ExitLevel()
	{
		nextLevelLight.SetActive(true);
	}
}
