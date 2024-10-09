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

	[SerializeField] private TMP_Text playerHealth;

	public void ChangeScore(int score)
	{
		totalScore += score;
		scoreboard.text = "Scoreboard: " + totalScore.ToString();
	}

	public void UpdateHealthUI(int health)
	{
		playerHealth.text = "Health: " + health.ToString();
	}
}
