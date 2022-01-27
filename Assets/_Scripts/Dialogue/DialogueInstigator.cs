using UnityEngine;

public class DialogueInstigator : MonoBehaviour
{
    [SerializeField] private DialogueChannel dialogueChannel;
    [SerializeField] private FlowChannel flowChannel;
    [SerializeField] private FlowState dialogueState;

    private DialogueSequencer dialogueSequencer;
    private FlowState cachedFlowState;

    private void OnDestroy(){}

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

        dialogueChannel.RaiseDialogueEnd(dialogue);
    }
}
