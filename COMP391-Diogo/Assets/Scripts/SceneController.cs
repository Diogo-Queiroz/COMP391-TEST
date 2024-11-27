using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
	public void PlayGame()
	{
		SceneManager.LoadScene("Gameplay");
	}
	public void PlayGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
