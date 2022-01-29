using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrimeSceneManager : MonoBehaviour
{
	public GameObject[] pictures;
	public GameObject inventoryUI;
	public Text pictureCountTxt;
	public int pictureCount;

	public GameObject kjazzUI;
	public GameObject exitLight;
	public GameObject mapLoader;

	private void Start()
	{
		pictureCount = 0;
		pictureCountTxt.text = pictureCount.ToString();
		inventoryUI.SetActive(false);

		PictureToggle(false);
		kjazzUI.SetActive(false);
		exitLight.SetActive(false);
		mapLoader.SetActive(false);
	}
	public void CrimeSceneStart()
	{
		inventoryUI.SetActive(true);
		PictureToggle(true);
	}
	public void UpdatePictureUI(int num)
	{

		pictureCountTxt.text = num.ToString();
	}
	private void PictureToggle(bool state)
	{
		foreach (GameObject pic in pictures)
		{
			pic.SetActive(state);
		}
	}
	public void PresentKJAZZClue()
	{
		exitLight.SetActive(true);
		StartCoroutine(KjazzCoroutine());
	}
	private IEnumerator KjazzCoroutine()
	{
		kjazzUI.SetActive(true);
		yield return new WaitForSeconds(2f);
		kjazzUI.SetActive(false);
	}
	public void ExitCrimeScene()
	{
		GameObject.FindWithTag("Player").GetComponent<PointAndClick_Movement>().enabled = false;

		//map loader doesn't respond to player input. for now just load next lvl
		mapLoader.SetActive(true);
		
	}
	private IEnumerator LoadLvl()
	{
		yield return new WaitForSeconds(3f);
		GameManager.Instance.LoadLevel(2);
	}
}
