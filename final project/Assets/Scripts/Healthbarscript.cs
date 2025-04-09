using UnityEngine;
using UnityEngine.UI; // For accessing UI components

public class HealthManager : MonoBehaviour
{
    // Declare UI components
    public Slider healthSlider;   // Slider for the health bar
    public Button damageButton;   // Button to take damage
    public Button healButton;     // Button to heal
    public Text healthText;       // Text to display health status

    // Initial Health value
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Set current health to max on startup

        // Initialize health bar
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        // Initialize health label
        UpdateHealthUI();

        // Add event listeners for buttons
        damageButton.onClick.AddListener(() => TakeDamage(10)); // Take 10 damage on button click
        healButton.onClick.AddListener(() => Heal(10));         // Heal 10 health on button click
    }

    // Method to handle taking damage and updating the health bar
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Ensure health doesn't go below 0
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();
    }

    // Method to heal the player and update the health bar
    private void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Ensure health doesn't go above maxHealth
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthUI();
    }

    // Method to update the health bar, label, and change bar color based on health
    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        healthText.text = $"Health: {currentHealth}/{maxHealth}";

        // Change health bar color based on current health
        if (currentHealth <= maxHealth * 0.2)
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.red; // Low health = Red
        }
        else if (currentHealth <= maxHealth * 0.5)
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.blue; // Medium health = Orange
        }
        else
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.green; // High health = Green
        }

        // Display "Game Over" message if health reaches 0
        if (currentHealth == 0)
        {
            Debug.Log("Game Over! You have no health left.");
        }
    }
}
