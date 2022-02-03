using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;

        public Animator animator;
        public Animator btnAnimator;
        public Animator shootAnimator;

        private Queue<string> sentences;
        private Queue<Dialogue> dialogueQueue;
        public static DialogueSystem Instance;

        private bool playerHasChose = false;
        private bool spare = false;
        public GameObject buttons;
        public GameObject CurtinScreen;

		private void Awake()
		{
            if (Instance == null)
                Instance = this;
			else
			{
                Destroy(gameObject);
                return;
			}
		}

		void Start()
        {
            sentences = new Queue<string>();
            dialogueQueue = new Queue<Dialogue>();
        }

        public void StartDialogue(Dialogue[] dialogue)
        {
            animator.SetBool("isOpen", true);

            sentences.Clear();

            foreach(Dialogue d in dialogue)
			{
                dialogueQueue.Enqueue(d);
			}
            Debug.Log(dialogueQueue.Count);

            nameText.text = dialogueQueue.Peek().name;
            

            Dialogue temp = dialogueQueue.Dequeue();

            foreach (string s in temp.sentences)
            {
                sentences.Enqueue(s);
            }
            
            DisplayNextSentence();
        }

		public void PlayerSpare(Dialogue[] spareDialogue)
		{
            spare = true;
            dialogueQueue.Clear();
            
            btnAnimator.SetTrigger("pier");
            playerHasChose = true;

            StartDialogue(spareDialogue);
		}
        public void PlayerShoot(Dialogue shootDialogue)
		{
            spare = false;
            sentences.Clear();

            CurtinScreen.SetActive(true);
            
            btnAnimator.SetTrigger("pier");
            //shootAnimator.SetTrigger("black");
            animator.SetBool("isOpen", true);

            playerHasChose = true;
            nameText.text = shootDialogue.name;

         

            foreach(string s in shootDialogue.sentences)
			{
                sentences.Enqueue(s);
			}

            DisplayNextSentence();
		}

		public void EndDialogue()
		{
            animator.SetBool("isOpen", false);
        }
        public void DisplayNextSentence()
		{

            //reached end of Q
            if(sentences.Count == 0)
			{
                if(dialogueQueue.Count == 0 && !playerHasChose)
				{
                    Debug.Log("no more dialogue");
                    ChooseShootOrSpare();
				}

                if(!playerHasChose)
				{

                    Dialogue temp = dialogueQueue.Dequeue();

                    nameText.text = temp.name;
                    Debug.Log("DisplayNextSentence->" + nameText.text);

                    foreach (string str in temp.sentences)
                    {
                        sentences.Enqueue(str);
                    }
                    string s = sentences.Dequeue();
                    dialogueText.text = s;
				}
				else
				{
                    if(spare)
					{
                        if (dialogueQueue.Count == 0)
                        {
                            Debug.Log("pier complete");
                            GameManager.Instance.PeirComplete();
                        }

                        Dialogue temp = dialogueQueue.Dequeue();

                        nameText.text = temp.name;
                        //Debug.Log("DisplayNextSentence->" + nameText.text);

                        foreach (string str in temp.sentences)
                        {
                            sentences.Enqueue(str);
                        }
                        string s = sentences.Dequeue();
                        dialogueText.text = s;
                    }
					else
					{
                        Debug.Log("pier complete");
                        GameManager.Instance.PeirComplete();
                    }
				}
			}
			else
			{
                string s = sentences.Dequeue();

                dialogueText.text = s;
			}
		}
        private void ChooseShootOrSpare()
		{
            EndDialogue();
            buttons.SetActive(true);
		}
       
        private IEnumerator TypeEffectCoroutine(string s)
		{
            dialogueText.text = "";

            foreach(char c in s.ToCharArray())
			{
                dialogueText.text += c;

                //wait one single frame
                yield return null;
			}
		}


    }
}
