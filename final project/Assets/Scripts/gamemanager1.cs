using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerWins = 0;
    public int enemyWins = 0;

    public TextMeshProUGUI winCounterText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager initialized.");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void ReportWin(string winnerTag)
    {
        if (winnerTag == "player")
            playerWins++;
        else if (winnerTag == "Enemy")
            enemyWins++;

        UpdateWinText();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
