using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent onInteraction;
    public UnityEvent doBeforeItDies;
    public GameObject gameObjectToReplaceOldDialogue;

    public void DoInteraction() 
    {
        onInteraction.Invoke();
    }
}
