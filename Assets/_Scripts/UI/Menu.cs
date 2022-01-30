using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public float creditsMovieLen;
	public GameObject introPaintings;

	private void Start()
	{
		introPaintings.SetActive(false);
		StartCoroutine(WaitForEndOfMovie());
	}
	private IEnumerator WaitForEndOfMovie()
	{
		yield return new WaitForSeconds(creditsMovieLen);
		introPaintings.SetActive(true);
	}

	public void LoadNextLevel()
	{
		AudioManager.instance.StopMenu();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
