using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GenericList<T>
{
    public T[] values;
    public GenericList()
    {
        values = new T[0];
    }
    public void Add(T value)
    {
        Array.Resize(ref values, values.Length + 1);
        values[values.Length - 1] = value;
    }
    public void PrintValues()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);
        }
    }
}

public class GenericExample : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>(); // More powerful version of Arrays
    public List<int> ints = new List<int>();
    public GenericList<float> floats = new GenericList<float>();
    
    void Start()
    {
        floats.Add(1f);
        floats.Add(5f);
        floats.PrintValues();
    }
}
