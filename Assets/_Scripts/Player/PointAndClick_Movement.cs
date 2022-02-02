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
	private RaycastHit hit;
	private float dist;

	private Animator anim;
	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		//cam always initialized to Main Camera
		cam = Camera.main;
	}
	
	private void Update()
    {
		dist = Vector3.Distance(transform.position, hit.point);
		//Debug.Log(dist);

		if (dist <= 0.1)
		{
			anim.SetBool("isWalking", false);
		}

		if (Input.GetMouseButtonDown(0))
		{
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);		
            

			if(Physics.Raycast(ray,out hit,Mathf.Infinity,playerLayerMask))
			{
				Debug.Log(hit.transform.gameObject.name);

				if (!hit.collider.CompareTag("Picture"))
				{
					agent.SetDestination(hit.point);
					if(!hit.collider.CompareTag("Wall"))
						anim.SetBool("isWalking", true);
					
				}
				else
					PicturePuzzle(hit);
			}

		}
    }
	
	private void PicturePuzzle(RaycastHit hit)
	{
		Inventory inv = GetComponent<Inventory>();
		if(inv != null && dist < 2f)
		{
			AudioManager.instance.Play("pick-up");

			inv.CollectPictureFragment();
			Destroy(hit.transform.gameObject);
		}
	}

    public void SwitchCamera(Camera c2)
	{
        cam = c2;
	}
}
