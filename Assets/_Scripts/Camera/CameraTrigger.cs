using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	private CameraManager m_cameraManager;
	public bool hasEntered = false;
	public string switchToCam;

	private void Start()
	{
		m_cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(hasEntered)
			{
				//Debug.Log("Player has already entered. Reentering old room");
				hasEntered = true;

				m_cameraManager.CameraSwitch(switchToCam, hasEntered);
			}
			else
			{
				//Debug.Log("Player has changed rooms for the first time");
				hasEntered = false;

				m_cameraManager.CameraSwitch(switchToCam, hasEntered);
			}

			
		}
	}
}
