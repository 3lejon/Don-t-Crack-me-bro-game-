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
// Call this method to display the game over screen with a custom message
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
// place this snipet on button to restart level or quit to main menu
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
