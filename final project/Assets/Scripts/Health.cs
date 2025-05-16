using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public TextMeshProUGUI healthText;   // Only needed for player
    public TextMeshProUGUI gameOverText; // Only needed for player
    public Animator animator;

    private bool isDead = false;
    internal int currentHealth;

    private Health playerHealthScript; // Reference to the player's Health script

    void Start()
    {
        health = maxHealth;

        if (CompareTag("player") && gameOverText != null)
            gameOverText.enabled = false;

        // Get the reference to the player's Health script if this is the enemy
        if (CompareTag("Enemy"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            if (player != null)
            {
                playerHealthScript = player.GetComponent<Health>();
            }
        }

        UpdateHealthUI();
    }

    public void ResetHealth()
    {
        health = maxHealth;  // Reset health to max value (100)
        isDead = false;      // Set isDead to false, so player can move again
        UpdateHealthUI();    // Update the health UI
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

                TriggerOtherPlayerVictory();
            }
            else if (CompareTag("Enemy"))
            {
                Debug.Log("Enemy Died!");
                if (animator != null)
                {
                    animator.SetTrigger("Die");
                    animator.SetTrigger("Death");
                }

                CheckForWinCondition(); // Player wins if enemy is dead
            }
        }
    }

    private void TriggerOtherPlayerVictory()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy != null)
        {
            Health EnemyHealth = Enemy.GetComponent<Health>();
            if (EnemyHealth != null && !EnemyHealth.isDead)
            {
                Animator EnemyAnim = EnemyHealth.animator;
                if (EnemyAnim != null)
                {
                    Debug.Log("Enemy Wins!");
                    EnemyAnim.SetTrigger("Victory");
                    EnemyAnim.SetTrigger("Win");
                }
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
