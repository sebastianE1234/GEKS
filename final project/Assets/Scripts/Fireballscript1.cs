using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 25f;
    public string shooterTag; // Tag of the player who shot this ("P1" or "P2")
    public Vector2 direction = Vector2.right;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Apply velocity (this is correct, no bs)
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore hitting the shooter
        if (other.CompareTag(shooterTag)) return;

        // Only damage the opponent
        if ((shooterTag == "P1" && other.CompareTag("P2")) ||
            (shooterTag == "P2" && other.CompareTag("P1")))
        {
            Debug.Log("🔥 Fireball hit opponent!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        // Destroy the fireball regardless of what it hits
        Destroy(gameObject);
    }
}
