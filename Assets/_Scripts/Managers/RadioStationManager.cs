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
	public GameObject stranger_CLUE;
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
		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = true;

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

		GameObject door = GameObject.Find("StrangerRoomMidPuzzle(Clone)");
		door.GetComponent<StangerDoorMidPuzzle>().SpawnFinalDoor();
	}
	
	public bool isPuzzleComplete()
	{
		return puzzleComplete;
	}

	public void SlipClue() 
	{
		print("SLIP");
		stranger_CLUE = GameObject.Find("NoInteractionStrangerRoom(Clone)").transform.GetChild(0).gameObject;
		stranger_CLUE.SetActive(true);
	}

	public void ExitLevel()
	{
		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = true;
		nextLevelLight.SetActive(true);
		// stranger_CLUE.SetActive(true);
	}
}
