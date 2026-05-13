using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public Text gameOverText;
    public string message = "Game Over";

    void Awake()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        if (gameOverPanel == null)
        {
            Debug.LogWarning("Gameover: gameOverPanel is not assigned.");
            return;
        }

        if (gameOverText != null)
        {
            gameOverText.text = message;
        }

        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
