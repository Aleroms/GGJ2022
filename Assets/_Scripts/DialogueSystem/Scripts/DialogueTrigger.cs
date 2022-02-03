using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
		public GameObject dialoguePanel;
        public Dialogue[] dialogue;
		public Dialogue shootDialogue;
		public Dialogue[] spareDialogue;

		private bool spare;

        public void TriggerDialogue()
		{
            DialogueSystem.Instance.StartDialogue(dialogue);
		}
		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Player"))
			{
				GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().stopMovement();
				GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;

				dialoguePanel.SetActive(true);
				TriggerDialogue();
			}
		}
		private void Update()
		{
			if(Input.GetButtonDown("Submit"))
			{
				
				DialogueSystem.Instance.DisplayNextSentence();
			}
		}
		public void PlayerChoice(bool state)
		{
			//add animation to fade out buttons
			spare = state;

			if (spare == false)
			{
				DialogueSystem.Instance.PlayerShoot(shootDialogue);
			}
			else
			{
				DialogueSystem.Instance.PlayerSpare(spareDialogue);
			}
		}
	}
}
