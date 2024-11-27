using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsExample : MonoBehaviour
{
    // A event will be created here to be called after some time. 
    public static event UnityAction debugEvent = delegate { };

    private void Start()
    {
        StartCoroutine(CallDebugEvent());
    }

    private IEnumerator CallDebugEvent()
    {
        yield return new WaitForSeconds(3);
        if (debugEvent != null)
        {
            debugEvent.Invoke();
        }
    }
}
