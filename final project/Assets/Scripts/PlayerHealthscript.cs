using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Reference to the UI Health Slider

    void Start()
    {
        currentHealth = maxHealth;

        // Set the initial value of the health slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Clamp the health to avoid going below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar UI
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Optional: Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., show a Game Over screen)
        Debug.Log("Player has died!");
        // You could add additional death logic here, such as disabling movement or triggering animations
    }
}
