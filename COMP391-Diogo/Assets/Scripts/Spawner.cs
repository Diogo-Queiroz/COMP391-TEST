using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    void Start()
    {
        for(int i = 0; i < (int)DificultyManager.instance.selectedDificulty; i++)
        {
            Instantiate(prefab, new Vector2(Random.Range(-5f, 5f), Random.Range(0f, 4.5f)), Quaternion.identity);
        }
    }
}
