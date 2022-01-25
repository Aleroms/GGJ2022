using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private PointAndClick_Movement playerCamera;

    public Camera[] Cameras;
    public string prevCam, currCam;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PointAndClick_Movement>();
        currCam = GameObject.FindGameObjectWithTag("MainCamera").name;
        prevCam = null;

        for(int i = 1; i < Cameras.Length; i++)
		{
            //MainCamera is starting camera; all others are disabled;
            if(Cameras[i].name != "MainCamera")
			{
                Cameras[i].enabled = false;
			}
		}
        
    }

   public void CameraSwitch(string switchToCam, bool hasEntered)
	{
        if (switchToCam == "")
		{
            Debug.LogWarning("Camera parameter passed is empty!");
            return;
		}

        if(currCam == switchToCam)
		{
            switchToCam = prevCam;
            Debug.Log("current camera (" + currCam + ") will switch to " + switchToCam);
        }
		else
		{
            Debug.Log("current camera (" + currCam + ") will switch to " + switchToCam);

		}

        int len = Cameras.Length;

        foreach(Camera cam in Cameras)
		{
            Debug.Log("---" + cam.name + "---");

            if(switchToCam == cam.name)
			{
                if(hasEntered == false)
				{
                    //first time entering room
                    prevCam = currCam;
                    currCam = switchToCam;
                    cam.enabled = true;

                    Debug.Log("Switching to " + cam.name);
                    playerCamera.SwitchCamera(cam);
				}
				else
				{
                    Debug.Log("cam has already been switched");
                    //reentering previous room
                    currCam = prevCam;
                    prevCam = currCam;
                    cam.enabled = true;
				}
			}
			else
			{
                Debug.Log("Disabling cam " + cam.name);
                cam.enabled = false;
                len--;
            }
            
        }
        if (len < 1) Debug.LogError("All Cameras Turned Off");
        
	}
}
