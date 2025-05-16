using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public int playerWins = 0;
    public int enemyWins = 0;
    public TextMeshProUGUI winCounterText;

    public bool isGameOver = false; // ? Game Over state

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this between scenes
            Debug.Log("GameManager initialized.");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ReportWin(string winnerTag)
    {
        isGameOver = true; // ? Game ends when someone wins

        if (winnerTag == "player")
            playerWins++;
        else if (winnerTag == "Enemy")
            enemyWins++;

        UpdateWinText();

        // You can add UI Game Over display here too if you want

        StartCoroutine(RestartAfterDelay(3f));
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

        // Restart game
        isGameOver = false; // Reset game over state before scene reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        // Optional manual restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver() // ? Call this if you want to stop the game (e.g., player death)
    {
        isGameOver = true;

        // Optional: Freeze time if you want everything to pause immediately
        // Time.timeScale = 0;

        Debug.Log("Game Over triggered");
    }

    public void ResetPlayerHealth()
    {
        GameObject player = GameObject.FindWithTag("player");
        if (player != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.ResetHealth();
            }
        }
    }
}
