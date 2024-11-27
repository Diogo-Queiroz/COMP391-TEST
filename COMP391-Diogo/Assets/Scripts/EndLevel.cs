using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";

    private void Awake()
    {
        EventsExample.debugEvent += DebugMessage;
    }

    private void DebugMessage()
    {
        Debug.Log("FINAL MESSAGE, CALLING ALL ASTRONAUTS TO MISSION!!!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other is player
        if (other.gameObject.tag.Equals("Player"))
        {
            // We get the SceneController component from this
            // We call the PlayGame and pass the nextSceneName
            SceneController.instance.PlayGame(nextSceneName);
        }
    }
}
