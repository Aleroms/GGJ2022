using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Flow/Flow Channel")]
public class FlowChannel : ScriptableObject
{
    public delegate void FlowStateCallback(FlowState state);
    public FlowStateCallback onFlowStateRequested;
    public FlowStateCallback onFlowStateChanged;

    public void RaiseFlowStateRequest(FlowState state) 
    {
        onFlowStateRequested?.Invoke(state);
    }

    public void RaiseFlowStateChanged(FlowState state) 
    {
        onFlowStateChanged?.Invoke(state);
    }
}