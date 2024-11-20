using System;
using UnityEngine;

public class DificultyManager : MonoBehaviour
{
    public static DificultyManager instance;
    public Dificulties selectedDificulty { get; private set; }

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

    public void SetDificulty(int index)
    {
        selectedDificulty = (Dificulties)Enum.GetValues(typeof(Dificulties)).GetValue(index);
    }
}
