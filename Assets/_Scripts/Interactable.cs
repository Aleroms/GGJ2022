using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent onInteraction;

    public void DoInteraction() 
    {
        onInteraction.Invoke();
    }
}
