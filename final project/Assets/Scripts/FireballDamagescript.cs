using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;  // Speed at which the fireball moves
    public int damage = 20;    // Amount of damage the fireball deals

    [System.Obsolete]
    void Start()
    {
        // Make the fireball move forward when the game starts
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Assuming fireball is moving in the forward direction (e.g., right)
            rb.velocity = transform.right * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the fireball hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Player script and apply damage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destroy the fireball after collision
            Destroy(gameObject);
        }
        else
        {
            // Destroy fireball if it hits something else
            Destroy(gameObject);
        }
    }
}
