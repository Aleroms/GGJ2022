using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	[SerializeField] private int gatingMechanism;
	private bool elecPuzzSolved;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

	}
	private void Start()
	{
		gatingMechanism = 0;
		elecPuzzSolved = false;
	}
	
	public void LoadLevel(int lvl)
	{
		try
		{
			SceneManager.LoadScene(lvl);
		}
		catch
		{
			Debug.LogError("lvl index passed NOT VALID");
		}
	}
	public int GetCurrentLevel()
	{
		return gatingMechanism;
	}
	public void CrimeSceneComplete()
	{
		GameObject.Find("CrimeSceneManager").GetComponent<CrimeSceneManager>().PresentKJAZZClue();

		Debug.Log("RCV Crime Scene Complete...");
		gatingMechanism++;
		Debug.Log("gating mechanism: " + gatingMechanism);
	}
	public void RadioStationComplete()
	{
		Debug.Log("RCV Radio Station Complete...");
		gatingMechanism++;
		Debug.Log("gating mechanism: " + gatingMechanism);
	}
	public void ElectronicsPuzzleComplete()
	{
		Debug.Log("Electronic Puzzle Solved");
		gatingMechanism++;
		elecPuzzSolved = true;
	}
	public void CarShopComplete()
	{
		Debug.Log("Car Shop Complete...");
		AudioManager.instance.Play("map-open");
		gatingMechanism++;
	}
	public void PeirComplete()
	{
		AudioManager.instance.Stop("pier-loop");
		AudioManager.instance.Play("credits");

		Debug.Log("Pier Complete...");
		gatingMechanism++;


		SceneManager.LoadScene("Credits");
	}
	public void Quit()
	{

		Debug.Log("Quitting");
		Application.Quit();

	}


}
