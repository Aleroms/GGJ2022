using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PointAndClick_Movement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
			{
                agent.SetDestination(hit.point);
			}

		}
    }

    public void SwitchCamera(Camera c2)
	{
        cam = c2;
	}
}
