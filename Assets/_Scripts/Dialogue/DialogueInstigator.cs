using UnityEngine;
using System.Collections;

public class DialogueInstigator : MonoBehaviour
{
    [SerializeField] private DialogueChannel dialogueChannel;
    [SerializeField] private FlowChannel flowChannel;
    [SerializeField] private FlowState dialogueState;

    private DialogueSequencer dialogueSequencer;
    private FlowState cachedFlowState;

    private void Awake() 
    {
        dialogueSequencer = new DialogueSequencer();

        dialogueSequencer.onDialogueStart += OnDialogueStart;
        dialogueSequencer.onDialogueEnd += OnDialogueEnd;
        dialogueSequencer.onDialogueNodeStart += dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.onDialogueNodeEnd += dialogueChannel.RaiseDialogueNodeEnd;

        dialogueChannel.onDialogueRequested += dialogueSequencer.StartDialogue;
        dialogueChannel.onDialogueNodeRequested += dialogueSequencer.StartDialogueNode;
    }

    private void OnDestroy()
    {
        dialogueChannel.onDialogueNodeRequested -= dialogueSequencer.StartDialogueNode;
        dialogueChannel.onDialogueRequested -= dialogueSequencer.StartDialogue;

        dialogueSequencer.onDialogueNodeEnd -= dialogueChannel.RaiseDialogueNodeEnd;
        dialogueSequencer.onDialogueNodeStart -= dialogueChannel.RaiseDialogueNodeStart;
        dialogueSequencer.onDialogueEnd -= OnDialogueEnd;
        dialogueSequencer.onDialogueStart -= OnDialogueStart;
    }

    private void OnDialogueStart(Dialogue dialogue) 
    {
        dialogueChannel.RaiseDialogueStart(dialogue);

        cachedFlowState = FlowStateMachine.Instance.CurrentState;
        flowChannel.RaiseFlowStateRequest(dialogueState);
    }

    private void OnDialogueEnd(Dialogue dialogue) 
    {
        flowChannel.RaiseFlowStateRequest(cachedFlowState);
        cachedFlowState = null;

        // Debug.Log("END");\
        GameObject gameObjectToDestroy = this.gameObject.GetComponent<InteractionInstigator>().gameObjectToDestroy;

        if (gameObjectToDestroy) {
            GameObject i = gameObjectToDestroy.GetComponent<Interactable>().gameObjectToReplaceOldDialogue;
            this.gameObject.GetComponent<InteractionInstigator>().EmptyInteractables();
            if (i) {
                GameObject e = Instantiate(i, gameObjectToDestroy.transform.position, gameObjectToDestroy.transform.rotation);
            }
            gameObjectToDestroy.GetComponent<Interactable>().doBeforeItDies.Invoke();
            Destroy(this.gameObject.GetComponent<InteractionInstigator>().gameObjectToDestroy);
        }

        // Debug.Log(e);

        dialogueChannel.RaiseDialogueEnd(dialogue);
    }
}
