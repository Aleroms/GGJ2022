using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPainting : MonoBehaviour
{
	public Image currentPainting;
	public Text currText;
    public Sprite[] panels;

	[TextArea(3,10)]
	public string[] narration;
	public float typeWriterSpeed;
	public float panelFadeSpeed;

	public int textIndex;
	public int panelIndex;
	private void Start()
	{
		textIndex = 0;
		panelIndex = 0;

		currentPainting.sprite = panels[0];
		StartCoroutine(TypeWriterEffectCoroutine(narration[0]));
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			textIndex++;

			if (textIndex == 21)
			{
				AudioManager.instance.Stop("menu-loop");
				AudioManager.instance.Play("bar-loop");
				GameManager.Instance.LoadLevel(1);
				return;
			}

			StopAllCoroutines();
			StartCoroutine(TypeWriterEffectCoroutine(narration[textIndex]));

			if (textIndex == 5)
			{
				//first transition; Fade
				panelIndex++;

				StartCoroutine(FadeImage(true));
				
			}
			else if (textIndex == 7)
			{
				//second transition; Hard Jump
				panelIndex++;
				currentPainting.sprite = panels[panelIndex];
			}
			else if (textIndex == 12)
			{
				//third transition; Hard Jump
				panelIndex++;
				currentPainting.sprite = panels[panelIndex];
			}
			else if (textIndex == 20)
			{
				//4th transition
				panelIndex++;
				currentPainting.sprite = panels[panelIndex];

				panelFadeSpeed = 3f;
				StartCoroutine(FadeImage(true));
			}
			
		}
	}
	private IEnumerator TypeWriterEffectCoroutine(string s)
	{
		currText.text = "";

		foreach(char c in s.ToCharArray())
		{
			currText.text += c;
			yield return new WaitForSeconds(typeWriterSpeed);
		}
	}
	private IEnumerator PanelFadeEffectCoroutine()
	{
		panelIndex++;
		//currentPainting.sprite = panels[panelIndex];

		float targetAlpha = 40f;

		for(int a = 255; a > targetAlpha; a--)
		{
			currentPainting.color = new Color(currentPainting.color.r, currentPainting.color.g, currentPainting.color.b, a);
			yield return null;
		}
	}
	private IEnumerator FadeImage(bool fadeAway)
	{
		// fade from opaque to transparent
		if (fadeAway)
		{
			// loop over 1 second backwards
			for (float i = panelFadeSpeed; i >= 0; i -= Time.deltaTime)
			{
				// set color with i as alpha
				currentPainting.color = new Color(1, 1, 1, i);
				yield return null;
			}

			if(textIndex == 5)
			{
				currentPainting.sprite = panels[panelIndex];

				// loop over 1 second
				for (float i = 0; i <= panelFadeSpeed; i += Time.deltaTime)
				{
					// set color with i as alpha
					currentPainting.color = new Color(1, 1, 1, i);
					yield return null;
				}
			}

			
		}
		// fade from transparent to opaque
		else
		{
			// loop over 1 second
			for (float i = 0; i <= panelFadeSpeed; i += Time.deltaTime)
			{
				// set color with i as alpha
				currentPainting.color = new Color(1, 1, 1, i);
				yield return null;
			}
		}
	}






}
