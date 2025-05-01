using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool IsDead { get; private set; } = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        currentHealth -= amount;
        Debug.Log("AI health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        IsDead = true;
        Debug.Log("AI died.");
        Destroy(gameObject);
    }
}
