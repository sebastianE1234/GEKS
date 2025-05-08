using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Max health value
    private int currentHealth; // Current health
    public Animator animator; // Reference to the animator
    public string deathAnimationTrigger = "Die"; // Animation trigger name for death animation

    void Start()
    {
        // Initialize the current health at the start
        currentHealth = maxHealth;
    }

    // Call this method to damage the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle the death logic
    private void Die()
    {
        // Play death animation by triggering the "Die" trigger in the Animator
        animator.SetTrigger(deathAnimationTrigger);

        // Optionally, disable further interactions, like movement or colliders
        GetComponent<Collider>().enabled = false; // Disable collider if necessary
        GetComponent<PlayerHealth>().enabled = false; // Disable the health script so no more damage can be taken
    }
}
