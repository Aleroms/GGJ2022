using System.Collections.Generic;
using UnityEngine;

public class InteractionInstigator : MonoBehaviour
{
    private List<Interactable> nearbyInteractables = new List<Interactable>();
    public GameObject gameObjectToDestroy;

    public bool HasNearbyInteractables() 
    {
        return nearbyInteractables.Count != 0;
    }

    private void Update() 
    {
        if (HasNearbyInteractables() && Input.GetButtonDown("Submit")) 
        {
            print("Do Interaction");
            gameObjectToDestroy = nearbyInteractables[0].gameObject;
            nearbyInteractables[0].DoInteraction();
        }
    }

    public void EmptyInteractables() 
    {
        nearbyInteractables.Clear();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null) 
        {
            nearbyInteractables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null) 
        {
            nearbyInteractables.Remove(interactable);
        }
    }
}
