using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueChoiceController : MonoBehaviour
{
    [SerializeField] private TMP_Text choice;
    [SerializeField] private DialogueChannel dialogueChannel;

    [SerializeField] private DialogueNode choiceNextNode;

    public DialogueChoice Choice 
    {
        set 
        {
            choice.text = value.ChoicePreview;
            // choice.gameObject.GetComponentInChildren<Text>().text = value.ChoicePreview;
            choiceNextNode = value.ChoiceNode;
            // print(choiceNextNode);
        }
    }

    private void Start() 
    {
        print(GetComponent<Button>());
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick() 
    {
        dialogueChannel.RaiseRequestDialogueNode(choiceNextNode);
    }
}
