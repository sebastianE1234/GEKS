using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public TextMeshProUGUI healthText;   // Only needed for player
    public TextMeshProUGUI gameOverText; // Only needed for player
    public Animator animator;

    private bool isDead = false;

    private Health playerHealthScript; // Reference to the player's Health script

    void Start()
    {
        currentHealth = maxHealth;

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
        currentHealth = maxHealth;  // Reset to max
        isDead = false;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (CompareTag("player") && healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }

        if (CompareTag("Enemy") && healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        UpdateHealthUI();

        Debug.Log($"{gameObject.name} took {amount} damage. Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            isDead = true;

            // Stop all movement on playermovement2 and playermovement3 if they exist
            playermovement2 movementScript2 = GetComponent<playermovement2>();
            if (movementScript2 != null) movementScript2.isDead = true;

            playermovement3 movementScript3 = GetComponent<playermovement3>();
            if (movementScript3 != null) movementScript3.isDead = true;

            if (CompareTag("player"))
            {
                Debug.Log("Player Died! Game Over!");
                if (gameOverText != null) gameOverText.enabled = true;
                if (animator != null) animator.SetTrigger("dead");

                TriggerOtherPlayerVictory();
            }
            else if (CompareTag("Enemy"))
            {
                Debug.Log("Enemy Died!");
                if (animator != null) animator.SetTrigger("Death");

                CheckForWinCondition();
            }
        }
    }

    void TriggerOtherPlayerVictory()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null && !enemyHealth.isDead)
            {
                Animator enemyAnim = enemyHealth.animator;
                if (enemyAnim != null)
                {
                    Debug.Log("Enemy Wins!");
                    enemyAnim.SetTrigger("Victory");
                }
            }
        }
    }

    void CheckForWinCondition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (player != null && enemy != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            Health enemyHealth = enemy.GetComponent<Health>();

            if (playerHealth != null && enemyHealth != null &&
                playerHealth.currentHealth > 0 && enemyHealth.currentHealth <= 0)
            {
                // Stop movement
                playermovement2 wanda = player.GetComponent<playermovement2>();
                if (wanda != null) wanda.isDead = true;

                playermovement3 westley = player.GetComponent<playermovement3>();
                if (westley != null) westley.isDead = true;

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
