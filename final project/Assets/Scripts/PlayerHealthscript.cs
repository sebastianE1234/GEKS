using UnityEngine;

public class PlayerHealthscript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;  // Initialize player's health
    }

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Ensure health doesn't go below zero
        if (currentHealth < 0)
        {
            currentHealth = 0;
            // Optional: Trigger death or game over logic here
            Debug.Log("Player is dead!");
        }

        Debug.Log("Player health: " + currentHealth);
    }

    // You can also add healing methods or other health-related functions here
}
