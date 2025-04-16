using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 25f;
    public string shooterTag;
    public Vector2 direction = Vector2.right;

    private Rigidbody2D rb;
    private float spawnTime;
    private float gracePeriod = 0.05f; // Time in seconds to ignore all triggers

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;
        spawnTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 🔐 Ignore all collisions in the first few milliseconds
        if (Time.time - spawnTime < gracePeriod) return;

        // 🛑 Don't hit the shooter
        if (other.CompareTag(shooterTag)) return;

        // ✅ Hit opponent only
        if ((shooterTag == "P1" && other.CompareTag("P2")) ||
            (shooterTag == "P2" && other.CompareTag("P1")))
        {
            Debug.Log("🔥 Fireball hit opponent!");
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            if()
        }
    }
}
