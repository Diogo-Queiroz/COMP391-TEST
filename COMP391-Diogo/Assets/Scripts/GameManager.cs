using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance
	{
		get 
		{
			if (instance != null) { return instance; }
			instance = FindObjectOfType(typeof(GameManager)) as GameManager;
			if (instance == null)
			{
				Debug.Log("Game Manager not found");
			}
			return instance;
		}
	}


	[SerializeField] private TMP_Text scoreboard;
	private int totalScore = 0;
	private int totalAsteroids = 0;

	[SerializeField] private TMP_Text playerHealth;

	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject endGamePanel;
	[SerializeField] private TMP_Text endGameTxt;

	public bool GameIsPaused = false;

	public void ChangeScore(int score)
	{
		totalScore += score;
		scoreboard.text = "Scoreboard: " + totalScore.ToString();
	}

	public void UpdateHealthUI(int health)
	{
		playerHealth.text = "Health: " + health.ToString();
	}

	public void AsteroidDestroyed()
	{
		// Reduce the number of asteroids
		totalAsteroids--;
		// If the number of asteroids is 0 or less, the game is won and ended
		if (totalAsteroids <= 0)
		{
			EndGame("Game Won with Score of " + totalScore.ToString());
		}		
	}

	public void EndGame(string message)
	{
		// Enable the text in the middle with the message
		endGamePanel.SetActive(true);
		endGameTxt.text = message;
		// Call coroutine for 3 seconds before navigating to Main Menu
		StartCoroutine(NavigatingToMenu(message, 3f));
	}

	private IEnumerator NavigatingToMenu(string message, float time)
	{
		while (time >= 0)
		{
			endGameTxt.text = message + ", returning to menu in " + time.ToString() + " sec.";
			yield return new WaitForSeconds(1);
			time--;
		}
		// Call sceneController to change scene to mainmenu
		GetComponent<SceneController>().PlayGame("MainMenu");
	}

    private void Start()
    {
        totalAsteroids = GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			GameIsPaused = !GameIsPaused;
							// If GameIsPause ? True : False
			Time.timeScale = GameIsPaused ? 0f : 1f; // Ternary operator is a shorthand version of if else statement
			pausePanel.SetActive(GameIsPaused);
			SoundManager.Instance.ChangeVolume(GameIsPaused);
		}
    }

	public void QuitGame()
	{
		#if !UNITY_EDITOR
			Application.Quit();
		#elif UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
