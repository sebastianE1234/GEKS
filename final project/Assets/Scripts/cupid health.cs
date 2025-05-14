using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class cupidhealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public Animator animator;

    private bool isDead = false;

    void Start()
    {
        health = maxHealth;

        if (gameOverText != null)
            gameOverText.enabled = false;

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;
        UpdateHealthUI();

        if (health <= 0)
        {
            isDead = true;

            Debug.Log("Player Died! Game Over!");

            if (gameOverText != null)
                gameOverText.enabled = true;

            if (animator != null)
                animator.SetTrigger("dead");

            if (GameManager.Instance != null)
                GameManager.Instance.ReportWin("Enemy"); // Enemy wins if player dies
        }
    }
}
