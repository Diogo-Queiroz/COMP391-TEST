using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
