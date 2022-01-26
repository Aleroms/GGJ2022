using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	private int gatingMechanism;

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
	}
	public void CrimeSceneComplete()
	{
		Debug.Log("RCV Crime Scene Complete...");
		gatingMechanism++;
		Debug.Log("gating mechanism: " + gatingMechanism);
	}


}
