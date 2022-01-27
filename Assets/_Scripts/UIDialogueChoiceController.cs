using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField] private Button choice;
    [SerializeField] private DialogueChannel dialogueChannel;

    private DialogueNode choiceNextNode;

    public DialogueChoice Choice 
    {
        set 
        {
            // choice.text = value.ChoicePreview;
            choice.gameObject.GetComponentInChildren<Text>().text = value.ChoicePreview;
            choiceNextNode = value.ChoiceNode;
        }
    }

    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick() 
    {
        dialogueChannel.RaiseRequestDialogueNode(choiceNextNode);
    }
}
