using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public TextMeshProUGUI healthText;   // Assign this in the Inspector
    public TextMeshProUGUI gameOverText; // Assign this in the Inspector
    public string deathAnimationTrigger = "Die";
    public Animator animator;

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
        health -= amount;
        UpdateHealthUI();

        if (health <= 0)
        {
            Debug.Log("Game Over!");
            gameOverText.enabled = true;

            if (animator != null)
            {
                animator.SetTrigger(deathAnimationTrigger);
            }
        }
    }
}
