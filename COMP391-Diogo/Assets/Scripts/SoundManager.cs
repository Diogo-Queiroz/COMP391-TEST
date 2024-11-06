using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
	public static SoundManager Instance
	{
		get 
		{
			if (instance != null) { return instance; }
			instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
			if (instance == null)
			{
				Debug.Log("Sound Manager not found");
			}
			return instance;
		}
	}
    
	[SerializeField] private AudioSource backgroundMusic;
	private float minVolume = 0f;
	private float maxVolume = 1f;

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
		maxVolume = backgroundMusic.volume;
		minVolume = maxVolume * 0.25f;
    }

    public void ChangeVolume(bool gameStatus)
	{
		backgroundMusic.volume = gameStatus ? minVolume : maxVolume;
	}
}
