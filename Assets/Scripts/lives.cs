using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public static Lives Instance; // Singleton for easy access

    [Header("Lives Settings")]
    public int maxLives = 1; // Total lives player starts with
    public GameObject playerPrefab; 
    public Transform spawnPoint;
    public float respawnDelay = 3f; // Time before player respawns after death

    [Header("UI")]
    public UnityEngine.UI.Text livesText; // Assign a UI Text component

    private int currentLives; 
    private GameObject currentPlayer; 

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = maxLives;
       
    }

    public void PlayerDied()
    {
        currentLives--;
        
        if (currentLives > 0)
        {
            // Respawn after delay
            Invoke("SpawnPlayer", respawnDelay);
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {        Debug.Log("Game Over!");
        // add game over UI, restart scene, etc. later
        // For now, reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}