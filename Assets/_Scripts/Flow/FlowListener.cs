using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FlowListenerEntry
{
    public FlowState state;
    public UnityEvent _event;
}

public class FlowListener : MonoBehaviour
{
    [SerializeField] private FlowChannel channel;
    [SerializeField] private FlowListenerEntry[] entries;

    private void Awake() 
    {
        channel.onFlowStateChanged += OnFlowStateChanged;
    }

    private void OnDestroy() 
    {
        channel.onFlowStateChanged -= OnFlowStateChanged;
    }

    private void OnFlowStateChanged(FlowState state) 
    {
        FlowListenerEntry foundEntry = Array.Find(entries, x => x.state == state);
        if (foundEntry != null) 
        {
            foundEntry._event.Invoke();
        }
    }
}
