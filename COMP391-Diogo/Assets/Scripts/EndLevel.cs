using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other is player
        if (other.gameObject.tag.Equals("Player"))
        {
            // We get the SceneController component from this
            // We call the PlayGame and pass the nextSceneName
            GetComponent<SceneController>().PlayGame(nextSceneName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collison");
    }
}
