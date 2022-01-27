using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void LoadNextLevel()
	{
		AudioManager.instance.StopMenu();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
