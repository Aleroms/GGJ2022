using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GeneratedDialogue : MonoBehaviour
{
    [System.Serializable]
    public class TestDia 
    {
        [TextArea(3, 10)]
        public string text;
        public SpeakerProfile speaker;
    }

    // [Header("Dialogue Stuff")]
    public TestDia[] dialogues;
    public float charDelay;
    private float timeToNextChar;
    private int dialogueIndex = -1;
    private int charIndex = -1;
    public TMP_Text textbox, nameText;

    // [Header("Speech Stuff")]
    private float pitch, pitchVariance, speed;

    public AudioClip[] phonemes;
    private AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        textbox.text ="";
    }


    // Update is called once per frame
    private void Update()
    {
        timeToNextChar -= Time.deltaTime;

        if (dialogueIndex != -1 && timeToNextChar <= 0f && charIndex < dialogues[dialogueIndex].text.Length - 1) 
        {
            // AddCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {}
    }

    private void NextDialogue() 
    {
        charIndex = -1;
        dialogueIndex++;
        // SwitchSpeaker();
    }

    private void AddCharacter() 
    {
        string currentText = dialogues[dialogueIndex].text;
        charIndex++;
        textbox.text = currentText.Substring(0, charIndex + 1);
        char letter = currentText[charIndex];

        // letter that require pausing
        if (letter == ',' || letter == '-' || letter == '.' || letter == '!' || letter == '?' || letter == ':')
        {
            timeToNextChar = charDelay * 8;
        }
        else if (char.IsNumber(letter)) 
        {
            timeToNextChar = charDelay * 3;
        }
        else 
        {
            timeToNextChar = charDelay;
        }

        if (char.IsLetterOrDigit(letter)) {}
    }
}
