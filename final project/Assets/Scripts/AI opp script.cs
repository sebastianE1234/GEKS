using UnityEngine;

public class AIOpponent : MonoBehaviour
{
    public Transform player;
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float shootCooldown = 2f;
    public float shootRange = 3f;
    public float moveSpeed = 2f;
    private bool facingRight = true; 

    private float shootTimer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Grab the Rigidbody2D on start
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Determine movement direction
        float moveDirection = player.position.x - transform.position.x;

        // Flip if necessary
        if (moveDirection > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && facingRight)
        {
            Flip();
        }

        // Move towards player
        if (distance > 1f)
        {
            rb.velocity = new Vector2(Mathf.Sign(moveDirection) * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Shooting logic
        shootTimer -= Time.deltaTime;

        if (distance <= shootRange)
        {
            if (shootTimer <= 0f)
            {
                Vector2 shootDir = (player.position - transform.position).normalized;
                Shoot(shootDir);
                shootTimer = shootCooldown;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void Shoot(Vector2 direction)
    {
        // Only use horizontal direction
        direction = new Vector2(Mathf.Sign(direction.x), 0f);  // Keep only X direction (left or right)

        Vector2 spawnPosition = (Vector2)firePoint.position + direction.normalized * 0.5f;

        GameObject fireball = Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}