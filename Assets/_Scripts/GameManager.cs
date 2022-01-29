using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	[SerializeField] private int gatingMechanism;
	[SerializeField] private int level;
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
		level = 0;
		elecPuzzSolved = false;
	}
	private void Update()
	{
		/*For Testing Only*/
		if(Input.GetKeyDown(KeyCode.P))
		{
			level++;

			if (level > 4)
				level = 0;

			SceneManager.LoadScene(level);
		}



	}
	public void testLevelLoader()
	{
			level++;

			if (level > 4)
				level = 0;

			SceneManager.LoadScene(level);
		
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
		elecPuzzSolved = true;
	}


}
