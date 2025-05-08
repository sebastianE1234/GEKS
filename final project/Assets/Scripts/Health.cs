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
        else
        {
            CheckForWinCondition();
        }
    }

    void CheckForWinCondition()
    {
        Debug.Log($"Checking win condition. Player health: {health}, Enemy health: {(enemyHealth != null ? enemyHealth.health : -1)}");

        if (health > 1 && enemyHealth != null && enemyHealth.health <= 0)
        {
            Debug.Log("You Win!");
            if (animator != null)
            {
                animator.SetTrigger("win");
            }
        }
    }


    private System.Collections.IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Enchanted Forest");
    }
}
