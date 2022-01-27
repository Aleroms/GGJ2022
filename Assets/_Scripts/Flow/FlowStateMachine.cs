using UnityEngine;

public class FlowStateMachine : MonoBehaviour
{
    [SerializeField] private FlowChannel channel;
    [SerializeField] private FlowState startupState;

    private FlowState currentState;
    public FlowState CurrentState => currentState;

    private static FlowStateMachine msInstance;
    public static FlowStateMachine Instance => msInstance;

    private void Awake() 
    {
        msInstance = this;
        channel.onFlowStateRequested += SetFlowState;
    }

    private void Start() 
    {
        SetFlowState(startupState);
    }

    private void OnDestroy() 
    {
        channel.onFlowStateRequested -= SetFlowState;

        msInstance = null;
    }

    private void SetFlowState(FlowState state) 
    {
        if (currentState != state) 
        {
            currentState = state;
            channel.RaiseFlowStateChanged(currentState);
        }
    }
}
