using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int pictureFragment;

	private void Start()
	{
		pictureFragment = 0;
	}
	public void CollectPictureFragment()
	{
		pictureFragment++;

		Debug.Log("Total pictures collected: " + pictureFragment);
		
		//update UI
		
		if(pictureFragment > 2)
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
