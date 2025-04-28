using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



=======
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public void RestartLevel()
    {
        Time.timeScale = 1; // Unfreeze the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("OpeningScreen");
    }
    public void GoForward()
    {
        SceneManager.LoadScene("Encanted forest");
    }

    public TextMeshProUGUI gameOverText;
    private bool isDead = false;

    public int health = 50;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.enabled = false;

        Time.timeScale = 1; // Ensure time is running when the game starts
    }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }

        // Restart with the R key (optional)
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        isDead = true;

        if (gameOverText != null)
        {
            gameOverText.text = "Game Over";
            gameOverText.enabled = true;
        }

        Time.timeScale = 0;
    }
}