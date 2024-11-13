using UnityEngine;
using UnityEngine.UI;

public class MenuControlller : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitGameButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        SceneController.instance.PlayGame("Intermission");
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif !UNITY_EDITOR
            Application.Quit();
        #endif
    }
}
