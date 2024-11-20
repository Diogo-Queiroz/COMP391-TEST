using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DificultySelection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private void Start()
    {
        dropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> dificultyOptions = new();
        string[] dificultyNames = System.Enum.GetNames(typeof(Dificulties));
        for(int i = 0; i < dificultyNames.Length; i++)
        {
            dificultyOptions.Add(new TMP_Dropdown.OptionData(dificultyNames[i]));
        }
        dropdown.AddOptions(dificultyOptions);
        DificultyManager.instance.SetDificulty(0);
        dropdown.onValueChanged.AddListener(DificultyManager.instance.SetDificulty);
    }
}
