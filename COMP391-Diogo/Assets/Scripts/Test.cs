using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello from Test");
    }
    void FixedUpdate()
    {
        Debug.Log("Hello from FixedUpdate");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello from update");
    }
    void LateUpdate()
    {
        Debug.Log("Hello from late update");
    }
    void OnEnable()
    {
        Debug.Log("Hello from Enable");
    }
    void OnDisable()
    {
        Debug.Log("Hello from Disable");
    }
}
