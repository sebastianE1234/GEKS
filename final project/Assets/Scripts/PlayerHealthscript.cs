using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player took damage: " + damage); // Confirm damage is happening
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!");
            // Add game-over logic here if needed
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }
}