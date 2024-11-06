using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void PlayGame()
	{
		SceneManager.LoadScene("Gameplay");
	}
	public void PlayGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
