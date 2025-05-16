using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class health2 : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public TextMeshProUGUI healthText;   // Only needed for player
    public TextMeshProUGUI gameOverText; // Only needed for player
    public Animator animator;

    private bool isDead = false;
    internal int currentHealth;

    void Start()
    {
        health = maxHealth;

        if (CompareTag("player") && gameOverText != null)
            gameOverText.enabled = false;

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

            // Stop all movement
            cupidmovement cupid = GetComponent<cupidmovement>();
            if (cupid != null)
            {
                cupid.isDead = true;
            }

            heliosmovement helios = GetComponent<heliosmovement>();
            if (helios != null)
            {
                helios.isDead = true;
            }

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
                    animator.SetTrigger("Die");

                CheckForWinCondition(); // Player wins if enemy is dead
            }
        }

        void TriggerOtherPlayerVictory()
        {
            throw new NotImplementedException();
        }

        void CheckForWinCondition()
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            if (player != null)
            {
                health2 playerHealth = player.GetComponent<health2>();
                if (!(playerHealth == null || playerHealth.isDead))
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

}



