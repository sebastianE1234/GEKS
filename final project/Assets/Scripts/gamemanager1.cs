using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public int playerWins = 0;
    public int enemyWins = 0;

    public TextMeshProUGUI winCounterText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy the GameManager
            Debug.Log("GameManager initialized.");
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // If there's already an instance, destroy this one
        }
    }

    public void ReportWin(string winnerTag)
    {
        if (winnerTag == "player")
            playerWins++;
        else if (winnerTag == "Enemy")
            enemyWins++;

        UpdateWinText();
        StartCoroutine(RestartAfterDelay(3f));  // Restart game after a delay
    }

    void UpdateWinText()
    {
        if (winCounterText != null)
        {
            winCounterText.text = $"Player Wins: {playerWins} | Enemy Wins: {enemyWins}";
        }
    }

    System.Collections.IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reload the scene to reset everything, but keep the player and other objects intact
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reset player health (this will be called again once the scene is reloaded)
        ResetPlayerHealth();
    }

    void ResetPlayerHealth()
    {
        // Find the player and reset health
        GameObject player = GameObject.FindWithTag("player");
        if (player != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.ResetHealth(); // Reset the health of the player
            }
        }
    }

    void Update()
    {
        // Optional: Press R to restart manually
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
