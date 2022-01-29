using UnityEngine;
using UnityEngine.Events;

public class StartingDialogue : MonoBehaviour
{
    [SerializeField] UnityEvent onInteraction;

    private void Start() 
    {
        DoInteraction();
    }

    public void DoInteraction() 
    {
        onInteraction.Invoke();
    }
}
