using System;
using UnityEngine;

public class DificultyManager : Singleton<DificultyManager>
{
    public Dificulties selectedDificulty { get; private set; }

    public void SetDificulty(int index)
    {
        selectedDificulty = (Dificulties)Enum.GetValues(typeof(Dificulties)).GetValue(index);
    }
}
