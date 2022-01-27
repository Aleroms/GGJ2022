using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public DialogueCallback onDialogueRequested;
    public DialogueCallback onDialogueStart;
    public DialogueCallback onDialogueEnd;

    public delegate void DialogueNodeCallback(DialogueNode node);
    public DialogueNodeCallback onDialogueNodeRequested;
    public DialogueNodeCallback onDialogueNodeStart;
    public DialogueNodeCallback onDialogueNodeEnd;

    public void RaiseRequestedDialogue(Dialogue dialogue) 
    {
        onDialogueRequested?.Invoke(dialogue);
    }

    public void RaiseDialogueStart(Dialogue dialogue) 
    {
        onDialogueStart?.Invoke(dialogue);
    }

    public void RaiseDialogueEnd(Dialogue dialogue) 
    {
        onDialogueEnd?.Invoke(dialogue);
    }

    public void RaiseRequestDialogueNode(DialogueNode node) 
    {
        onDialogueNodeRequested?.Invoke(node);
    }

    public void RaiseDialogueNodeStart(DialogueNode node) 
    {
        onDialogueNodeStart?.Invoke(node);
    }

    public void RaiseDialogueNodeEnd(DialogueNode node) 
    {
        onDialogueNodeEnd?.Invoke(node);
    }
}
