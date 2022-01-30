using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueTextBoxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image speakerImage;

    [SerializeField] private RectTransform choicesBoxTransform;
    [SerializeField] private UIDialogueChoiceController choiceControllerPrefab;

    [SerializeField] private DialogueChannel dialogueChannel;

    public GameObject destroyOnEnd;

    private bool listenToInput = false;
    private DialogueNode nextNode = null;

    private void Awake() 
    {
        dialogueChannel.onDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.onDialogueNodeEnd += OnDialogueNodeEnd;

        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy() 
    {
        dialogueChannel.onDialogueNodeEnd -= OnDialogueNodeEnd;
        dialogueChannel.onDialogueNodeStart -= OnDialogueNodeStart;
    }

    private void Update() 
    {
        if (listenToInput && Input.GetButtonDown("Submit")) 
        {
            dialogueChannel.RaiseRequestDialogueNode(nextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        dialogueText.text = node.DialogueLine.Text;
        speakerText.text = node.DialogueLine.Speaker.CharacterName;
        // Texture2D tempPic = new Texture2D(2,2);
        speakerImage.sprite = Sprite.Create(node.DialogueLine.Speaker.CharacterPortrait, new Rect(0,0,1024,1024), new Vector2());

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node) 
    {
        nextNode = null;
        listenToInput = false;
        dialogueText.text = "";
        speakerText.text = "";
        speakerImage.sprite = null;

        foreach(Transform child in choicesBoxTransform) 
        {
            Destroy(child.gameObject);
        }

        // if (node.CanBe)

        gameObject.SetActive(false);
        choicesBoxTransform.gameObject.SetActive(false);
    }

    // private void o
    public void Visit(BasicDialogueNode node)
    {
        listenToInput = true;
        nextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        choicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices) 
        {
            UIDialogueChoiceController newChoice = Instantiate(choiceControllerPrefab, choicesBoxTransform);
            newChoice.Choice = choice;
        }
    }
}
