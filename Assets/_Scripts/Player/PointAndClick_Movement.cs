using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class PointAndClick_Movement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		//cam always initialized to Main Camera
		cam = Camera.main;
	}
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
