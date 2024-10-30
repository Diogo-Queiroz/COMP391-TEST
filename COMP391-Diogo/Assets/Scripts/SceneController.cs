using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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
