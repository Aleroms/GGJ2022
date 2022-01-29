using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	CrimeSceneManager crimeManager; 
	private int pictureFragment;

	private void Start()
	{
		crimeManager = GameObject.Find("CrimeSceneManager").GetComponent<CrimeSceneManager>();
		pictureFragment = 0;
	}
	public void CollectPictureFragment()
	{
		pictureFragment++;

		Debug.Log("Total pictures collected: " + pictureFragment);

		//update UI
		crimeManager.UpdatePictureUI(pictureFragment);
		
		if(pictureFragment > 4)
		{
			//Notify GM that you collected all pictureFrag for lvl CS01
			Debug.Log("Player has collected all picture fragments... Notifying GameManager");

			if (GameManager.Instance != null)
				GameManager.Instance.CrimeSceneComplete();
			else
				Debug.LogError("GameManager Instance is NULL");
		}
	}
}
