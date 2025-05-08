using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    void Start()
    {
        health = maxHealth;
        gameOverText.enabled = false;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
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
            Debug.Log("Game Over!");
            gameOverText.enabled = true;

            if (animator != null)
            {
            }
        }
    }
}