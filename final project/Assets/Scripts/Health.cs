using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public TextMeshProUGUI healthText;   // Only needed for player
    public TextMeshProUGUI gameOverText; // Only needed for player
    public Animator animator;

    private bool isDead = false;

    void Start()
    {
        health = maxHealth;

        if (CompareTag("player") && gameOverText != null)
            gameOverText.enabled = false;

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (CompareTag("player") && healthText != null)
        {
            healthText.text = "Health: " + health;
        }

        if (CompareTag("Enemy") && healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }



    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;
        UpdateHealthUI();

        if (health <= 0)
        {
            isDead = true;

            if (CompareTag("player"))
            {
                Debug.Log("Player Died! Game Over!");
                if (gameOverText != null)
                    gameOverText.enabled = true;

                if (animator != null)
                    animator.SetTrigger("dead");

                
            }
            else if (CompareTag("Enemy"))
            {
                Debug.Log("Enemy Died!");
                if (animator != null)
                    animator.SetTrigger("Die");

                CheckForWinCondition(); // Let the player win if enemy is dead
            }
        }
    }

    void CheckForWinCondition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null && !playerHealth.isDead)
            {
                Animator playerAnim = playerHealth.animator;
                if (playerAnim != null)
                {
                    Debug.Log("Player Wins!");
                    playerAnim.SetTrigger("win");
                }
            }
        }
    }
}
