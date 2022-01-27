using UnityEngine;
using TMPro;

public class UIInteractionTextController : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private InteractionInstigator watchedInteractionInstigator;

    private void Update() 
    {
        text.enabled = watchedInteractionInstigator.enabled && watchedInteractionInstigator.HasNearbyInteractables();
    }
}
