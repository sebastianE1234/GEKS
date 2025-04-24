using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    private bool isDead = false;

    // Example health system (adjust as needed)
    public int health = 50;

    void Start()
    {
        gameOverText.enabled = false;
    }
    void Update()
    {
        // Check if the player is dead
        if (health <= 0 && !isDead)
        {
            Die();
        }

    }

    // Simulate player taking damage
    void TakeDamage(int damage)
    {
        health -= damage;
    }

    // This method is called when the player dies
    void Die()
    {
        isDead = true;
        gameOverText.text = "Game Over";  // Display the Game Over message
        gameOverText.enabled = true;  // Make the Game Over text visible
        Time.timeScale = 0;  // Freeze the game (optional, to stop gameplay)
    }

}