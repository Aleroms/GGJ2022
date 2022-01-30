using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPainting : MonoBehaviour
{
	public Image currentPainting;
	public Text currText;
    public Sprite[] panels;
	public string[] narration;

	public float textTimer;
	public float waitTillStartGame;

	private void Start()
	{
		
		StartCoroutine(PaintingCoroutine());
	}
	private IEnumerator PaintingCoroutine()
	{
		/*		Painting 1		*/
		currentPainting.sprite = panels[0];
		currText.text = narration[0];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[1];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[2];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[3];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[4];
		yield return new WaitForSeconds(textTimer);

		/*		Painting 2		*/
		currentPainting.sprite = panels[1];
		currText.text = narration[5];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[6];

		/*		Painting 3		*/
		currentPainting.sprite = panels[2];
		currText.text = narration[7];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[8];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[9];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[10];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[11];
		yield return new WaitForSeconds(textTimer);

		/*		Painting 4		*/
		currentPainting.sprite = panels[3];
		currText.text = narration[12];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[13];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[14];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[15];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[16];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[17];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[18];
		yield return new WaitForSeconds(textTimer);
		currText.text = narration[19];
		yield return new WaitForSeconds(textTimer);

		/*		Painting 4		*/
		currentPainting.sprite = panels[4];
		currText.text = narration[20];
		yield return new WaitForSeconds(waitTillStartGame);

		GameManager.Instance.LoadLevel(1);

	}



}
