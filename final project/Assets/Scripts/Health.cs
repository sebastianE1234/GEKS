using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public TextMeshProUGUI healthText;   // Assign in Inspector
    public TextMeshProUGUI gameOverText; // Assign in Inspector
    public Animator animator;            // Assign in Inspector

    private bool isDead = false;

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
                animator.SetTrigger("dead"); // Trigger "Dead" animation
            }

            // Start coroutine to delay scene load
            StartCoroutine(HandleDeath());
        }
    }

    private System.Collections.IEnumerator HandleDeath()
    {
        // Wait for animation to play (adjust this duration to match your animation length)
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Enchanted Forest");
    }
}
