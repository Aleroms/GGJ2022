using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class PointAndClick_Movement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
	private int playerLayerMask = 3;

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

            //if(Physics.Raycast(ray, out hit,playerLayerMask))
			if(Physics.Raycast(ray,out hit,Mathf.Infinity,playerLayerMask))//100f max dist
			{
				Debug.Log(hit.transform.gameObject.name);

				if (!hit.collider.CompareTag("Picture"))
					agent.SetDestination(hit.point);
				else
					PicturePuzzle(hit);
			}

		}
    }
	private void PicturePuzzle(RaycastHit hit)
	{
		Inventory inv = GetComponent<Inventory>();
		if(inv != null)
		{
			inv.CollectPictureFragment();
			Destroy(hit.transform.gameObject);
		}
	}

    public void SwitchCamera(Camera c2)
	{
        cam = c2;
	}
}
