using UnityEngine;


public class FireballDamage : MonoBehaviour
{
    public int damageAmount = 20; // How much damage the fireball deals
    public float destroyAfterSeconds = 5f; // Auto-destroy in case it doesn't hit

    private void Start()
    {
        // Destroy fireball after a while if it doesn't hit anything
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we hit has a Health component
        PlayerHealth targetHealth = other.GetComponent<PlayerHealth>();
        if (targetHealth != null)
        {
            // Deal damage
            targetHealth.TakeDamage(damageAmount);
            

            // Destroy the fireball on hit
            Destroy(gameObject);
        }
        else
        {
            // Optional: destroy it anyway if it hits something else
            Destroy(gameObject);
        }
    }
}

