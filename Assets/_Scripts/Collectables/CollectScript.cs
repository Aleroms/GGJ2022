using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour, ICollectable
{
	private Inventory inventory;
	public float clueAudioLen = 3;

	private void Start()
	{
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}
	public void Collect()
	{
		Debug.Log("--notify inventory.cs of collected item--");
		inventory.CollectPictureFragment();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Collect();
			Destroy(gameObject, clueAudioLen);
		}
	}
}
