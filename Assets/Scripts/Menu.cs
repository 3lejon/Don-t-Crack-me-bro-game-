using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Tutorial stage"); //load the game
    }

    public void OnQuitButton()
    {
        Application.Quit(); // quits the game

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // stop Play mode in the Editor
#endif
    }
}
